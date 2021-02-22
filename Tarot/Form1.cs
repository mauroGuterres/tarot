using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Allan_Tarot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form4();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Form5();
            form.Show();
        }
    }
}
