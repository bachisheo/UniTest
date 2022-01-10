using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using University.Models;

namespace University
{
    public partial class TableViewForm : Form
    {

        public TableViewForm()
        {
            InitializeComponent();
            var context = new unitest_01Context();

            // var cmd = new NpgsqlCommand("select * from student;", connect);
           dataGridView1.DataSource = context.Student.Local;
            dataGridView1[1, 1] = new DataGridViewButtonCell();

            //Server=34.140.136.71;Port=5432;Database=unitest_01   ;User Id=postgres; password=0489;
            //dotnet ef dbcontext scaffold "Server=34.140.136.71;Database=unitest_01;Username=postgres;Password=0489" Npgsql.EntityFrameworkCore.PostgreSQL
            // Scaffold-DbContext "Server=34.140.136.71;Database=unitest_01;Username=postgres;Password=0489;" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models
            //
        context.Dispose();

        }
    }
}
