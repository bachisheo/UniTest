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
    public partial class Main_admin_form : Form
    {
        Form exit;
        public Main_admin_form(Form ex)
        {

            exit = ex;//для будущего выхода
            InitializeComponent();
        }

        private void Main_admin_form_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  exit.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableViewForm form = new TableViewForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
