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
    public partial class CustomerModuleForm : Form
    {
        OracleConnection con;
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        private void CustomerModuleForm_Load_1(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Save this Customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand insrtCtr = con.CreateCommand();
                insrtCtr.CommandText = "INSERT INTO tbCustomer VALUES(:cid, :cname, :cphone)";
                insrtCtr.Parameters.Add(new OracleParameter("cid", txtCid.Text));
                insrtCtr.Parameters.Add(new OracleParameter("cname", txtCName.Text));
                insrtCtr.Parameters.Add(new OracleParameter("cphone", txtCPhone.Text));
                insrtCtr.CommandType = CommandType.Text;
                try
                {
                    int row = insrtCtr.ExecuteNonQuery();
                    if (row > 0)
                    {
                        if (MessageBox.Show("Do you want to add more Customers?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            this.Dispose();
                        else
                        {
                            clear();
                        }
                    }
                    con.Close();
                    
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                        MessageBox.Show("Sorry, Customer with this ID already exits in the table.");
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
            txtCid.Clear();
        }

        public void clear()
        {
            txtCid.Clear();
            txtCName.Clear();
            txtCPhone.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void customerButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update this Customer?", "Updating Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand up = con.CreateCommand();
                up.CommandText = "UPDATE tbCustomer SET Cname = :cname, Cphone = :cphone WHERE Cid = :cid";
                up.CommandType = CommandType.Text;
                up.Parameters.Add(new OracleParameter("cname", txtCName.Text));
                up.Parameters.Add(new OracleParameter("cphone", txtCPhone.Text));
                up.Parameters.Add(new OracleParameter("cid", txtCid.Text));

                int row = up.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("Customer has been updated successfully.");
                    con.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Customer not matched in the table");
                    con.Close();
                    this.clear2();
                }
            }
        }

        private void txtCid_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
