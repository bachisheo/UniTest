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
            Tools.FillDG(dataGridView1, "select * from statement_header", "statement_header");
          
            DataTable tab = Tools.GetDataTable("select name from discipline;");
            if (dataGridView1.Rows.Count == 2)
                return;
            //фильтр по дисциплине

            comboBoxDisc.DataSource = tab;
            comboBoxDisc.DisplayMember = "name";

        }


     

        private void button1_Click(object sender, EventArgs e)
        {
            String dis = comboBoxDisc.SelectedValue.ToString();

            Tools.FillDG(dataGridView1, "select * from result "+
            " inner join statement_header sh on result.statement_header_pk = sh.statement_header_pk "+
            " where result.gradebook_pk  = " + 1 + ";", "statement_header");

        }
    }
    }

