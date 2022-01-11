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
        private int _book_id = 1;
        public Main_student_form()
        {
            InitializeComponent();
            Tools.FillDG(dataGridView1, "select * from entry_in_study_statement ent " +
                                        " inner join discipline d on ent.discipline_pk = d.discipline_pk " +
                                        " inner join statement_header h on h.entry_in_study_statement_pk = ent.entry_in_study_statement_pk " +
                                        " inner join result r on h.statement_header_pk = r.statement_header_pk " +
                                        "  where r.gradebook_pk = " + _book_id.ToString() + ";",
                "statement_header");
            DataTable tab1 = Tools.GetDataTable("select name from discipline;");
            DataTable tab = Tools.GetDataTable("select number, gradebook_pk from gradebook where gradebook.student_pk = " + PgConnection.id.ToString()  + ";");
            comboBoxDisc.DataSource = tab;
            //it'a a name of column
            comboBoxDisc.DisplayMember = "number";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxDisc.SelectedIndex > 0)
            {
                var a  = comboBoxDisc.SelectedItem as DataRowView;
                _book_id = (int)a.Row[1];

                Tools.FillDG(dataGridView1, "select * from entry_in_study_statement ent " +
                                            " inner join discipline d on ent.discipline_pk = d.discipline_pk " +
                                            " inner join statement_header h on h.entry_in_study_statement_pk = ent.entry_in_study_statement_pk " +
                                            " inner join result r on h.statement_header_pk = r.statement_header_pk " +
                                            "  where r.gradebook_pk = " + _book_id.ToString() + ";",
                    "statement_header");
            }
        }
    }
    }

