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
    public partial class Main_student_form : Form
    {
        public Main_student_form()
        {
            InitializeComponent();
            Tools.FillDG(dataGridView1, "select * from statement_header", "");

            DataTable tab = Tools.GetDataTable("select name from discipline;", "");

            //фильтр по дисциплине
           
            comboBox1.DataSource = tab;
            comboBox1.DisplayMember = "name";

        }


     

        private void button1_Click(object sender, EventArgs e)
        {
            String dis = comboBox1.SelectedValue.ToString();

            Tools.FillDG(dataGridView1, "select * from statement_header where ", "");

        }
    }
    }

