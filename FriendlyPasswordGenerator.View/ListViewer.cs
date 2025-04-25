using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriendlyPasswordGenerator.View
{
    public partial class ListViewer : Form
    {
        public ListViewer(IEnumerable<string> items)
        {
            InitializeComponent();

            DataTable table = new();
            table.Columns.Add("Items", typeof(string));

            foreach (var item in items)
            {
                table.Rows.Add(item);
            }

            MainDataGridView.DataSource = table;
            MainDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
