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
    public partial class CustomerForm : Form
    {
        OracleConnection con;
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void customerForm_Load_1(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);

            LoadCustomer();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            con.Open();
            OracleCommand getCustomer = con.CreateCommand();
            getCustomer.CommandText = "Select * From tbCustomer";
            getCustomer.CommandType = CommandType.Text;
            OracleDataReader cDR = getCustomer.ExecuteReader();
            while (cDR.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, cDR[0].ToString(), cDR[1].ToString(), cDR[2].ToString());
            }
            cDR.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            CustomerModuleForm moduleForm = new CustomerModuleForm();

            if (colName == "Edit")
            {

                CustomerModuleForm cmModule = new CustomerModuleForm();
                cmModule.txtCid.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmModule.txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmModule.txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();

                cmModule.btnCSave.Enabled = false;
                cmModule.btnCUpdate.Enabled = true;
                cmModule.ShowDialog();
                LoadCustomer();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete this Customer?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    OracleCommand cmnd = con.CreateCommand();
                    cmnd.CommandText = "DELETE From tbCustomer WHERE cid LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cmnd.CommandType = CommandType.Text;

                    int rows = cmnd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Customer has Deleted Successfully!");

                    con.Close();
                }
            }
            LoadCustomer();
        }

        private void btnAd_Click(object sender, EventArgs e)
        {
            CustomerModuleForm moduleForm = new CustomerModuleForm();
            moduleForm.btnCSave.Enabled = true;
            moduleForm.btnCUpdate.Enabled = false;
            moduleForm.ShowDialog();
            LoadCustomer();
        }
    }
}
