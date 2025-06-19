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
    public partial class CatagoryForm : Form
    {
        OracleConnection con;
        public CatagoryForm()
        {
            InitializeComponent();
        }

        private void CatagoryForm_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);

            LoadCatagory();
        }
        public void LoadCatagory()
        {
            int i = 0;
            dgvCatagory.Rows.Clear();
            con.Open();
            OracleCommand getCatagory = con.CreateCommand();
            getCatagory.CommandText = "Select * From tbCatagory";
            getCatagory.CommandType = CommandType.Text;
            OracleDataReader catDR = getCatagory.ExecuteReader();
            while (catDR.Read())
            {
                i++;
                dgvCatagory.Rows.Add(i, catDR[0].ToString(), catDR[1].ToString());
            }
            catDR.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CatagoryModuleForm formModule = new CatagoryModuleForm();
            formModule.btnCSave.Enabled = true;
            formModule.btnCatUpdate.Enabled = false;
            formModule.ShowDialog();
            LoadCatagory();
        }

        private void dgvCatagory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCatagory.Columns[e.ColumnIndex].Name;
            CustomerModuleForm moduleForm = new CustomerModuleForm();

            if (colName == "Edit")
            {
                CatagoryModuleForm formModule = new CatagoryModuleForm();
                formModule.txtCatId.Text = dgvCatagory.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtCatName.Text = dgvCatagory.Rows[e.RowIndex].Cells[2].Value.ToString();

                formModule.btnCSave.Enabled = false;
                formModule.btnCatUpdate.Enabled = true;
                formModule.ShowDialog();
                LoadCatagory();

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete this Catagory?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    OracleCommand cmnd = con.CreateCommand();
                    cmnd.CommandText = "DELETE From tbCatagory WHERE catId LIKE '" + dgvCatagory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cmnd.CommandType = CommandType.Text;

                    int rows = cmnd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("Catagory has Deleted Successfully!");

                    con.Close();
                }
            }
            LoadCatagory();
        }
    }
}
