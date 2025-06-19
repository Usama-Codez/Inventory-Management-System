using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class CustomerButton : PictureBox
    {
        public CustomerButton()
        {
            InitializeComponent();
        }

        private void CustomerButton_Load(object sender, EventArgs e)
        {

        }

        private Image NormalImg;
        private Image HoverImg;

        public Image ImageNormal
        {
            get { return NormalImg; }
            set { NormalImg = value; }
        }

        public Image ImageHover
        {
            get { return HoverImg; }
            set { HoverImg = value; }
        }

        private void CustomerButton_MouseHover(object sender, EventArgs e)
        {
            this.Image = HoverImg;
        }

        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image = NormalImg;
        }
    }
}
