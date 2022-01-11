using Npgsql;
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
    public partial class Study_statement : Form
    {
        private string _cmnd, _view_name = "student_view", _table_name = "student";
        private string formName = "Студенты";
        public Study_statement(int id)
        {
            InitializeComponent();
            Tools.FillDG(dataGridView1, "SELECT * FROM statement_header a1  inner JOIN study_statement_header a2 on a1.statement_header_pk = a2.study_statement_header_pk WHERE a2.teacher_pk = " + id + ";", "");

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Удаление", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Экспорт", "Экспорт");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
           
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            //Вызываем нашу созданную эксельку.
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Delete":
                    {

                        var result = MessageBox.Show("Данные будут удалены безвозвратно. Вы уверены?", "Предупреждение",
                            MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                           // Tools.Execute("delete from " + _table_name + " where " + _table_name + "_pk = " + Tools.GetId(dataGridView1, e.RowIndex));
                         //   MyRefresh();
                        }

                        break;
                    }

                case "Экспорт":
                    {

                        // MessageBox.Show("Дада, сейчас?");
                        //  var add = new AddAndChange(true, dataGridView1.DataSource as DataTable,
                        //      Tools.GetId(dataGridView1, e.RowIndex));
                       
                        DataTable dt = new DataTable();
                        DataGridView dat = new DataGridView();
                      
                             Tools.FillDG(dat, "select * from result where statement_header_pk = "+Tools.GetId(dataGridView1, e.RowIndex)+";", "");
                      

                        //var b = a[0][1];

                        //textBox1.Text = ""+add_or_change; 

                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook  ExcelWorkBook;
                        Microsoft.Office.Interop.Excel.Worksheet  ExcelWorkSheet;
                        
                        
                        /*
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            ExcelApp.Cells[0, j + 1] = "";
                                }
                        */
                        for (int i = 0; i < dat.Rows.Count; i++)
                        {
                            for (int j = 0; j < dat.ColumnCount; j++)
                            {//
                                 ExcelApp.Cells[i + 1, j + 1] = dat.Rows[i].Cells[j].Value.ToString();
                                //ExcelApp.Cells[i + 1, j + 1] = a[i][j].ToString();
                            }
                        }

                        //Книга.
                        ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                        //Таблица.
                        ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                       
                        //Вызываем нашу созданную эксельку.
                        ExcelApp.Visible = true;
                        ExcelApp.UserControl = true;
                       
                        // add.ShowDialog();
                        //MyRefresh();
                        break;
                    }

            }

        }

        public void MyRefresh()
        {
            _view_name = "statement_header";
            Tools.FillDG(dataGridView1, "select * from statement_header; ", _view_name);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
  

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Экспорт", "Экспорт");

            // dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            rand.Next();
            var res = Tools.executeFunction(" select * from add_statement_header( "+ rand.Next().ToString() +
                                    ", "+rand.Next().ToString()+");");
            AddAndChange form = new AddAndChange(false, dataGridView1.DataSource as DataTable, res);
            form.ShowDialog();
            MyRefresh();
        }
    }
}
