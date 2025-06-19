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
    public partial class temp : Form
    {
        OracleConnection con;
        public temp()
        {
            InitializeComponent();
        }

        private void temp_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = Localhost:1521/xe; USER ID=IMS;PASSWORD=123";

            con = new OracleConnection(conStr);

            updateGrid();
        }
        private void updateGrid()

        {

            con.Open();

            OracleCommand getEmps = con.CreateCommand();

            getEmps.CommandText = "Select * From DEPT";

            getEmps.CommandType = CommandType.Text;

            OracleDataReader empDR = getEmps.ExecuteReader();

            DataTable empDT = new DataTable();

            empDT.Load(empDR);

            dataGridView1.DataSource = empDT;

            con.Close();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();

            OracleCommand insertEmp = con.CreateCommand();

            insertEmp.CommandText = "INSERT INTO DEPT VALUES(" + txtDeptNo.Text.ToString() +

              ",\'" + txtDeptName.Text.ToString() +

               "\',\'" + txtDeptLoc.Text.ToString() + "\')";

            insertEmp.CommandType = CommandType.Text;

            int rows = insertEmp.ExecuteNonQuery();

            if (rows > 0)

                MessageBox.Show("Data Inserted Successfully!");

            con.Close();

            updateGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();

            OracleCommand insertEmp = con.CreateCommand();

            insertEmp.CommandText = "UPDATE DEPT SET DNAME = '" + txtDeptName.Text.ToString() +

               "\'," + " LOC = " +

               "\'" + txtDeptLoc.Text.ToString() + "\'" +

               "WHERE " + "DEPTNO = " + txtDeptNo.Text.ToString();

            insertEmp.CommandType = CommandType.Text;

            int rows = insertEmp.ExecuteNonQuery();

            if (rows > 0)

                MessageBox.Show("Data Updated Successfully!");

            else

                MessageBox.Show("Data Not Updated!");

            con.Close();

            updateGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            OracleCommand insertEmp = con.CreateCommand();

            insertEmp.CommandText = "DELETE FROM DEPT WHERE DEPTNO = " +

             txtDeptNo.Text.ToString();

            insertEmp.CommandType = CommandType.Text;

            int rows = insertEmp.ExecuteNonQuery();

            if (rows > 0)

                MessageBox.Show("Data DELETED Successfully!");

            else

                MessageBox.Show("Data not found!");

            con.Close();

            updateGrid();
        }
    }
}
