using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SizeSelectionForm : Form
    {
        public SizeSelectionForm()
        {
            InitializeComponent();
        }

        private void btn2x2_Click(object sender, EventArgs e)
        {
            var form1 = new Form1(2);
            form1.Show();
            this.Hide();
        }

        private void btn3x3_Click(object sender, EventArgs e)
        {
            var form1 = new Form1(3);
            form1.Show();
            this.Hide();
        }

        private void btn4x4_Click(object sender, EventArgs e)
        {
            var form1 = new Form1(4);
            form1.Show();
            this.Hide();
        }

    }
}
