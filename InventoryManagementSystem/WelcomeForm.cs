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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            flowLayoutPanel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        int startingPiont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startingPiont += 2;
            progressBar1.Value = startingPiont;
            if(progressBar1.Value == 100)
            {
                timer1.Stop();
                progressBar1.Value = 0;
                Login log = new Login();
                this.Hide();
                log.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
