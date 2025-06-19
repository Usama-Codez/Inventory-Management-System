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
    public partial class ProductForm : Form
    {
        OracleConnection con;
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load_1(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
            LoadProduct();
        }

        private void butnAdd_Click(object sender, EventArgs e)
        {
            ProductModuleForm productModule = new ProductModuleForm();
            productModule.btnPSave.Enabled = true;
            productModule.btnPUpdate.Enabled = false;
            productModule.ShowDialog();
            LoadProduct();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            con.Open();
            OracleCommand getProcucts = con.CreateCommand();
            getProcucts.CommandText = "Select * From tbproduct Where Concat(pdescription, pcatagory) LIKE '%"+txtSearch.Text+ "%' OR Concat(pid, pprice) LIKE '%" + txtSearch.Text + "%' OR Concat(pname, pqty) LIKE '%" + txtSearch.Text + "%'";

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

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModuleForm pModule = new ProductModuleForm();
                pModule.txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                pModule.txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                pModule.txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                pModule.txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                pModule.txtPDesc.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                pModule.ComboCat.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();

                pModule.btnPSave.Enabled = false;
                pModule.btnPUpdate.Enabled = true;
                pModule.ShowDialog();
                LoadProduct();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete this Product Info?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    OracleCommand cmnd = con.CreateCommand();
                    cmnd.CommandText = "DELETE From tbProduct WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cmnd.CommandType = CommandType.Text;

                    int rows = cmnd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Product has Deleted Successfully!");

                    con.Close();
                }
            }
            LoadProduct();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
