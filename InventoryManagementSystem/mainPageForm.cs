using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mainPageForm : Form
    {
        public mainPageForm(string role)
        {
            InitializeComponent();
            if (role == "admin")
            {
                btnUser.Visible = true;
                btnCustomer.Visible = true;
                btnCatagory.Visible = true;
                btnProduct.Visible = true;
                btnOrder.Visible = true;
            }
            else if (role == "employee")
            {
                btnUser.Visible = false;
                btnCustomer.Visible = true;
                btnCatagory.Visible = true;
                btnProduct.Visible = true;
                btnOrder.Visible = true;
            }
            else if (role == "customer")
            {
                btnUser.Visible = false;
                btnCustomer.Visible = true;
                btnCatagory.Visible = false;
                btnProduct.Visible = true;
                btnOrder.Visible = true;
            }
            else
            {
                MessageBox.Show("Our System has Noticed that you are not a Admin, Employee OR Customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("If you are Admin, Employee OR Customer, please contact to DBA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private Form activeForm = null;
        private void openChildFrom(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildFrom(new UserForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
             openChildFrom(new CustomerForm());
        }

        private void btnCatagory_Click(object sender, EventArgs e)
        {
            openChildFrom(new CatagoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildFrom(new ProductForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildFrom(new OrderForm());
        }

        private void customerButton6_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really want to Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
