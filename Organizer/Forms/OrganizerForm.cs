using Equin.ApplicationFramework;
using Organizer.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Organizer
{
    public partial class OrganizerForm : Form
    {
        public OrganizerForm()
        {
            InitializeComponent();
        }
        readonly BusinessLogic businessLogic = new BusinessLogic();
        readonly Checking checking = new Checking();
        private void Form1_Load(object sender, EventArgs e)
        {
            checking.CheckingFile();
            List<Data> data = Data1.Value;
            BindingListView<Data> binding = new BindingListView<Data>(data);
            dataGridView1.DataSource = binding;
            dataGridView1.Columns[0].Width = 180;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 213;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 50;
            }
            for(int i = 4; i < 7; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            Data1.DataGrid = dataGridView1;
            int number = 0;
            foreach (Data data1 in data)
            {
                data1.ID = number;
                number += 1;
            }
            businessLogic.Message(Data1.DataGrid);
            businessLogic.UpdateTable(Data1.DataGrid);
            businessLogic.EditBackColor(Data1.DataGrid);
        }
        private void label3_Click(object sender, EventArgs e)
        {
            CreateTaskForm form2 = new CreateTaskForm();
            form2.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
            MessageBox.Show("Закрыть приложение?",
                           "Подтверждение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                businessLogic.ListData = Data1.Value;
                businessLogic.WriteToFile();
                this.Close();
            }
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                int tableindex = Data1.DataGrid.CurrentRow.Index;
                Data1.Index = index;
                Data1.TableIndex = tableindex;
                EditTaskForm form3 = new EditTaskForm();
                form3.Show();
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Данные некорректны",
                           "Ошибка",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);
            EditTaskForm form3 = new EditTaskForm();
            form3.Show();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            businessLogic.EditBackColor(Data1.DataGrid);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            businessLogic.UpdateTable(Data1.DataGrid);
            businessLogic.EditBackColor(Data1.DataGrid);
        }
    }
}