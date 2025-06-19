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
    public partial class OrderForm : Form
    {
        OracleConnection con;
        public OrderForm()
        {
            InitializeComponent();
        }

        private void butnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm orderModule = new OrderModuleForm();
            orderModule.btnOInsert.Enabled = true;
            orderModule.ShowDialog();
            LoadOrder();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
            LoadOrder();
        }

        public void LoadOrder()
        {
            double totalAmt = 0;
            int i = 0;
            dgvOrder.Rows.Clear();
            con.Open();
            OracleCommand getOrders = con.CreateCommand();
            getOrders.CommandText = "SELECT O.orderid, O.odate, O.pid, P.pname, O.cid, C.cname, O.qty, O.price, O.total FROM tbOrder O JOIN tbCustomer C ON O.cid = C.cid JOIN tbProduct P ON O.pid = P.pid WHERE CONCAT(O.orderid, O.odate) LIKE '%"+ txtSearch.Text + "%' OR CONCAT(O.pid, P.pname)  LIKE '%" + txtSearch.Text + "%' OR CONCAT(O.cid, C.cname) LIKE '%" + txtSearch.Text + "%' OR CONCAT(O.qty, O.price) LIKE '%" + txtSearch.Text + "%'";
            getOrders.CommandType = CommandType.Text;
            OracleDataReader oDR = getOrders.ExecuteReader();
            while (oDR.Read())
            {
                i++;
                dgvOrder.Rows.Add(oDR[0].ToString(), Convert.ToDateTime(oDR[1].ToString()).ToString("dd/MM/yyyy"), oDR[2].ToString(), oDR[3].ToString(), oDR[4].ToString(), oDR[5].ToString(), oDR[6].ToString(), oDR[7].ToString(), oDR[8].ToString());
                totalAmt += Convert.ToInt32(oDR[8].ToString());
            }
            oDR.Close();
            con.Close();

            txtQty.Text = i.ToString();
            txtAmt.Text = totalAmt.ToString();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;
            
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete this Order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    OracleCommand cmnd = con.CreateCommand();
                    cmnd.CommandText = "DELETE From tbOrder WHERE orderid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cmnd.CommandType = CommandType.Text;

                    int rows = cmnd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Order has Deleted Successfully!");

                    OracleCommand upd = con.CreateCommand();
                    upd.CommandText = "UPDATE tbProduct SET pqty= pqty + '" + Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()) + "' WHERE Pid  LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "'";
                    upd.CommandType = CommandType.Text;
                    upd.Parameters.Add(new OracleParameter("pqty", Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString())));
                    int rw = upd.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadOrder();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }
    }
}
