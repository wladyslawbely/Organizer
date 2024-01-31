using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Organizer.Forms
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        readonly BusinessLogic businessLogic = new BusinessLogic();
        private void Form4_Load(object sender, EventArgs e)
        {
            List<Data> data = Data1.Value2;
            BindingListView<Data> binding = new BindingListView<Data>(data);
            dataGridView1.DataSource = binding;
            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 183;
            dataGridView1.Columns[5].Width = 132;
            dataGridView1.Columns[6].Width = 132;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 50;
            }
            for (int i = 4; i < 5; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }

            Data1.DataGrid2 = dataGridView1;
            int number = 0;
            foreach (Data data1 in data)
            {
                data1.ID = number;
                number += 1;
            }
            businessLogic.EditBackColor(Data1.DataGrid2);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            businessLogic.ListHistoryData = Data1.Value2;
            businessLogic.WriteToFileHistory();
            this.Close();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            businessLogic.EditBackColor(Data1.DataGrid2);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            if (Data1.Value2.Count == 0)
            {
                MessageBox.Show("История на данный момент пустая",
                                    "Уведомление",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                filterForm.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            BindingListView<Data> binding = new BindingListView<Data>(Data1.Value2);
            Data1.DataGrid2.DataSource = binding;
            businessLogic.EditBackColor(Data1.DataGrid2);
        }
    }
}
