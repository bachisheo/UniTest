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
    public partial class AddAndChange : Form
    {
        public AddAndChange()
        {
            InitializeComponent();
        }

        public AddAndChange(bool add_or_change, DataGridViewRow str)

        {
            InitializeComponent();
          //  dataGridView1 = new DataGridView();
            dataGridView1.DataSource = str;
              //  Rows.Add(str);
              //textBox1.Text = ""+add_or_change;
        }
    }
}
