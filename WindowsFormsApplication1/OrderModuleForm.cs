using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApplication1
{
    public partial class OrderModuleForm : Form
    {
        OracleConnection con;
        int quantity = 0;
        public OrderModuleForm()
        {
            InitializeComponent();
        }

        private void OrderModuleForm_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
            LoadCustomer();
            LoadProduct();
        }

        private void customerButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            con.Open();
            OracleCommand getCustomer = con.CreateCommand();
            getCustomer.CommandText = "Select cid, cname From tbCustomer Where Concat(cid, cname) LIKE '%" + txtSearchCust.Text + "%'";
            getCustomer.CommandType = CommandType.Text;
            OracleDataReader cDR = getCustomer.ExecuteReader();
            while (cDR.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, cDR[0].ToString(), cDR[1].ToString());
            }
            cDR.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            con.Open();
            OracleCommand getProcucts = con.CreateCommand();
            getProcucts.CommandText = "Select * From tbproduct Where Concat(pdescription, pcatagory) LIKE '%" + txtSearchProd.Text + "%' OR Concat(pid, pprice) LIKE '%" + txtSearchProd.Text + "%' OR Concat(pname, pqty) LIKE '%" + txtSearchProd.Text + "%'";

            getProcucts.CommandType = CommandType.Text;
            OracleDataReader pDR = getProcucts.ExecuteReader();
            while (pDR.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, pDR[0].ToString(), pDR[1].ToString(), pDR[2].ToString(), pDR[3].ToString(), pDR[4].ToString(), pDR[5].ToString());
            }
            pDR.Close();
            con.Close();
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (txtOQty.Value > quantity)
            {
                MessageBox.Show("Instock Quantity is Not Enough", "Warning Stock Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOQty.Value = txtOQty.Value - 1;
                return;
            }
           
            if (txtOQty.Value > 0)
            {
                double total = Convert.ToInt32(txtOQty.Value) * Convert.ToInt32(txtPrice.Text);
                txtTotal.Text = total.ToString();
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            quantity = Convert.ToInt16(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void btnOInsert_Click(object sender, EventArgs e)
        {
            if (txtOrderId.Text == "")
            {
                MessageBox.Show("Please Insert Order Id First.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCId.Text == "" && txtPid.Text == "")
            {
                MessageBox.Show("Please Select Customer and Product First.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCId.Text == "")
            {
                MessageBox.Show("Please Select Customer and then try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPid.Text == "")
            {
                MessageBox.Show("Please Select Product and then try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Insert this Order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand insrt = con.CreateCommand();
                insrt.CommandText = "INSERT INTO tbOrder VALUES(:orderId, :oDate, :pid, :cid, :qty, :price, :total)";
                insrt.Parameters.Add(new OracleParameter("orderId", txtOrderId.Text));
                insrt.Parameters.Add(new OracleParameter("odate", txtODate.Value));
                insrt.Parameters.Add(new OracleParameter("pid", txtPid.Text));
                insrt.Parameters.Add(new OracleParameter("cid", txtCId.Text));
                insrt.Parameters.Add(new OracleParameter("qty", txtOQty.Value));
                insrt.Parameters.Add(new OracleParameter("price", txtPrice.Text));
                insrt.Parameters.Add(new OracleParameter("total", txtTotal.Text));
                
                insrt.CommandType = CommandType.Text;
                try
                {
                    int row = insrt.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Order has been saved sucessfully.");
                        OracleCommand upd = con.CreateCommand();
                        upd.CommandText = "UPDATE tbProduct SET pqty= pqty - '" + txtOQty.Value + "' WHERE Pid  LIKE '" + txtPid.Text + "'";
                        upd.CommandType = CommandType.Text;
                        upd.Parameters.Add(new OracleParameter("pqty", txtOQty.Value));
                        int rw = upd.ExecuteNonQuery();
                        con.Close();
                        clear();
                        LoadProduct();
                    }              
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                        MessageBox.Show("Sorry, but Order with Same Id already exist in the table");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        public void clear()
        {
            txtCId.Clear();
            txtCName.Clear();
            txtOrderId.Clear();
            txtPid.Clear();
            txtPName.Clear();
            txtPrice.Clear();
            txtSearchCust.Clear();
            txtSearchProd.Clear();
            txtTotal.Clear();
            txtOQty.Value = 0;
            txtODate.Value = DateTime.Now;     
        }

        private void btnOClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

        