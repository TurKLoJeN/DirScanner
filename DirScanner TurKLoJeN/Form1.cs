using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirScanner_TurKLoJeN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://turklojenofficial.com/"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wordlist files may take time to load as they are very large!!!");
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
