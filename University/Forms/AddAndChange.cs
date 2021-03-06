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
using System.Windows.Forms.VisualStyles;

namespace University.Forms
{
    public partial class AddAndChange : Form
    {
        private bool _isEdit;
        private int _id;
        private string _table_name;
        private string _view = "_view";
        public AddAndChange()
        {
            InitializeComponent();
           
        }
        public AddAndChange(DataTable dt)
        {
            _table_name = dt.TableName.Replace("_view", "");
            _isEdit = false;
            var _dt = dt;
            Tools.FillDG(dataGridView1, _dt);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Visible = false;
            }
            _dt.Rows.Add(1);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

            // dataGridView1.Rows.Add(1);
            ActionButton.Text = "Добавить";
        }

        public void MyRefresh()
        {
            var _dt = Tools.GetDataTableFromOneObj(_table_name + "_view", "id", _id.ToString());
            Tools.FillDG(dataGridView1, _dt);
            CancelButton.Enabled = false;
            ActionButton.Enabled = false;
        }


        public AddAndChange(bool isEdit, DataTable dt, int id)
        {
            _id = id;
            _isEdit = isEdit;
            InitializeComponent();
            _table_name = dt.TableName.Replace("_view", "");
            MyRefresh();
            if (isEdit)
            {
                ActionButton.Text = "Изменить";
                this.Text = "Изменить запись";
            }
            else
            {
                ActionButton.Text = "Добавить";
                this.Text = "Добавить запись";

            }
            MyRefresh();

            // dataGridView1.Rows.Add(str);
            //textBox1.Text = ""+add_or_change;
        }

        private void AddAndChange_Load(object sender, EventArgs e)
        {

        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var dt = dataGridView1.DataSource as DataTable;

                sb.Append("update " + _table_name + " set ");
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    if (i > 1 && i < dt.Columns.Count) sb.Append(" , ");
                    sb.Append(dt.Columns[i].ColumnName + " = '" + dt.Rows[0][i].ToString() + "' ");
                }
                sb.Append(" where " + _table_name + "_pk = " + _id.ToString() + ";");
            Tools.Execute(sb.ToString());
            if(!_isEdit) this.Close();
            MyRefresh();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (_isEdit)
                MyRefresh();
            else
            {
                Tools.Delete(_table_name, _table_name + "_pk", _id.ToString());
                this.Close();
            }
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            CancelButton.Enabled = true;
            ActionButton.Enabled = true;
        }
    }
}
