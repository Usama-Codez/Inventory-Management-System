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
    public partial class ProductModuleForm : Form
    {
        OracleConnection con;
        public ProductModuleForm()
        {
            InitializeComponent();
        }

        private void ProductModuleForm_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
            LoadCatag();
        }

        public void LoadCatag()
        {
            ComboCat.Items.Clear();
            con.Open();
            OracleCommand getQty = con.CreateCommand();
            getQty.CommandText = "Select catName From tbCatagory";
            getQty.CommandType = CommandType.Text;
            OracleDataReader qDR = getQty.ExecuteReader();
            
            while (qDR.Read())
            {
                ComboCat.Items.Add(qDR[0].ToString());
            }
            qDR.Close();
            con.Close();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void customerButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Save this Product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand insrt = con.CreateCommand();
                insrt.CommandText = "INSERT INTO tbProduct(pid, pname, pqty, pprice, pdescription, pcatagory) VALUES(:pid, :pname, :pqty, :pprice, :pdescription, :pcatagory)";
                insrt.Parameters.Add(new OracleParameter("pid", txtPid.Text));
                insrt.Parameters.Add(new OracleParameter("pname", txtPName.Text));
                insrt.Parameters.Add(new OracleParameter("pqty", txtPQty.Text));
                insrt.Parameters.Add(new OracleParameter("pprice", txtPPrice.Text));
                insrt.Parameters.Add(new OracleParameter("pdescription", txtPDesc.Text));
                insrt.Parameters.Add(new OracleParameter("pcatagory", ComboCat.Text));

                insrt.CommandType = CommandType.Text;
                try
                {
                    int row = insrt.ExecuteNonQuery();
                    if (row > 0)
                        MessageBox.Show("Product has been saved sucessfully.");
                    con.Close();
                    clear();
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                        MessageBox.Show("Sorry, but same Product already exist in the table");
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
            txtPid.Clear();
            txtPName.Clear();
            txtPPrice.Clear();
            txtPQty.Clear();
            txtPDesc.Clear();
            ComboCat.Text = " ";
        }

        private void btnPClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnPUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update this Product info?", "Updating Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand upd = con.CreateCommand();
                upd.CommandText = "UPDATE tbProduct SET pname = :pname, pqty = :pqty,  pprice = :pprice, pdescription = :pdescription, pcatagory = :pcatagory WHERE pid  = :pid";
                upd.CommandType = CommandType.Text;
                
                upd.Parameters.Add(new OracleParameter("pname", txtPName.Text));
                upd.Parameters.Add(new OracleParameter("pqty", txtPQty.Text));
                upd.Parameters.Add(new OracleParameter("pprice", txtPPrice.Text));
                upd.Parameters.Add(new OracleParameter("pdescription", txtPDesc.Text));
                upd.Parameters.Add(new OracleParameter("pcatagory", ComboCat.Text));
                upd.Parameters.Add(new OracleParameter("pid", txtPid.Text));

                int row = upd.ExecuteNonQuery();
                if (row > 0)
                    MessageBox.Show("Product Info has been updated successfully.");
                else
                    MessageBox.Show("Product ID not matched in the table");
                con.Close();
                this.Dispose();
            }
        }
    }
}
