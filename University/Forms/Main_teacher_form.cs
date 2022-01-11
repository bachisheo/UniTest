using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University.Forms
{
    public partial class Main_teacher_form : Form
    {
        public Main_teacher_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this.Visible = false;
            Bank_asks form = new Bank_asks(true, 1);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this.Visible = false;
            Bank_asks form = new Bank_asks(false, 1);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.Visible = false;
            Study_statement form = new Study_statement(1);
            form.ShowDialog();
        }
    }

    
}
