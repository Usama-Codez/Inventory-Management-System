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
    public partial class CatagoryModuleForm : Form
    {
        OracleConnection con;
        public CatagoryModuleForm()
        {
            InitializeComponent();
        }

        private void CatagoryModuleForm_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Save this Catagory?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    OracleCommand insrtCtgr = con.CreateCommand();
                    insrtCtgr.CommandText = "INSERT INTO tbCatagory VALUES(:catId, :catName)";
                    insrtCtgr.Parameters.Add(new OracleParameter("cid", txtCatId.Text));
                    insrtCtgr.Parameters.Add(new OracleParameter("cname", txtCatName.Text));
                    insrtCtgr.CommandType = CommandType.Text;

                    int row = insrtCtgr.ExecuteNonQuery();
                    if (row > 0)
                    {
                        if (MessageBox.Show("Do you want to add more Catagories?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            this.Dispose();
                    }
                    con.Close();
                    clear();
                }

                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                        MessageBox.Show("Sorry, Catagory with this ID already exit in the table.");
                        clear2();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }


        public void clear2()
        {
            txtCatId.Clear();
        }

        public void clear()
        {
            txtCatId.Clear();
            txtCatName.Clear();
        }

        private void btnCClear_Click(object sender, EventArgs e)
        {
            clear();
            btnCSave.Enabled = true;
            btnCatUpdate.Enabled = false;
        }

        private void btnCatUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update this Catagory?", "Updating Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand upda = con.CreateCommand();
                upda.CommandText = "UPDATE tbCatagory SET catname = :catname WHERE catid = :catid";
                upda.CommandType = CommandType.Text;
                upda.Parameters.Add(new OracleParameter("catName", txtCatName.Text));
                upda.Parameters.Add(new OracleParameter("catId", txtCatId.Text));
                int row = upda.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Catagory has been updated successfully.");
                    con.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Please Don't try to change Id. if you still want to add New Id. You can add a new Catagory in the Add Catagory tab.");
                    con.Close();
                    clear2();
                }
            }
        }

        private void customerButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
