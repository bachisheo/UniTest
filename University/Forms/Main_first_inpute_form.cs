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
    public partial class Main_first_inpute_form : Form
    {
        public Main_first_inpute_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text == "1")
            {
               // this.Visible = false;
                Main_admin_form form = new Main_admin_form(this);
                form.ShowDialog();
            }
            else
                 if (LoginBox.Text == "2")
            {
                Main_student_form form = new Main_student_form();
                form.ShowDialog();
            }
            else
            {
                Main_teacher_form form = new Main_teacher_form();
                form.ShowDialog();
            }
        }
    }
}
