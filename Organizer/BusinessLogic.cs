using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Organizer
{
    public class BusinessLogic
    {
        public List<Data> ListData { get; set; } = new List<Data>();
        public List<Data> ListHistoryData { get; set; } = new List<Data>();

        readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Data>));
        public void ReadFromFile()
        {
            List<Data> list = new List<Data>();
            {
                using (var file = new FileStream("Data.xml", FileMode.OpenOrCreate))
                    list = xmlSerializer.Deserialize(file) as List<Data>;
                if (list != null)
                {
                    ListData = list;
                }
                Data1.Value = ListData;
            }
        }
        public void WriteToFile()
        {
            using (var file = new FileStream("Data.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(file, ListData);
            }
        }
        public void ReadFromFileHistory()
        {
            List<Data> list = new List<Data>();
            {
                using (var file = new FileStream("DataHistory.xml", FileMode.OpenOrCreate))
                    list = xmlSerializer.Deserialize(file) as List<Data>;
                if (list != null)
                {
                    ListHistoryData = list;
                }
                Data1.Value2 = ListHistoryData;
            }
        }
        public void WriteToFileHistory()
        {
            using (var file = new FileStream("DataHistory.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(file, ListHistoryData);
            }
        }
        public string Time(DateTimePicker dateTimePicker, decimal a1, decimal a2)
        {
            string a12 = a1.ToString();
            if (a12.Length < 2)
            {
                a12 = "0" + a12;
            }
            string a22 = a2.ToString();
            if (a22.Length < 2)
            {
                a22 = "0" + a22;
            }
            string time = dateTimePicker.Value.ToShortDateString() + " " + a12 + ":" + a22;
            return time;
        }
        public void DeleteTask(DataGridView dataGridView1)
        {
            try
            {
                int ind = dataGridView1.CurrentCell.RowIndex, number = 0;
                int index = Convert.ToInt32(dataGridView1.Rows[ind].Cells[4].Value);
                Data1.Value.RemoveAt(index);
                foreach (Data data1 in Data1.Value)
                {
                    data1.ID = number;
                    number += 1;
                }
                EditBackColor(Data1.DataGrid);
                BindingListView<Data> binding = new BindingListView<Data>(Data1.Value);
                Data1.DataGrid.DataSource = binding;
                EditBackColor(Data1.DataGrid);
            }
            catch
            {
                MessageBox.Show("Вы не выбрали строку для удаления");
            }
        }
        public void AddToHistoryData(DataGridView dataGridView1)
        {
            int ind = Data1.DataGrid.CurrentCell.RowIndex;
            int index = Convert.ToInt32(Data1.DataGrid.Rows[ind].Cells[4].Value);
            List<Data> list;
            object w = dataGridView1.Rows[ind].Cells[3].Value;
            if (w.ToString() == "Выполнено")
            {
                if (Data1.Value2 == null)
                {
                    list = ListHistoryData;
                }
                else
                {
                    list = Data1.Value2;
                }
                list.Add(Data1.Value[index]);
                Data1.Value2 = list;
                Data1.Value.RemoveAt(index);
                int number = 0;
                foreach (Data data1 in Data1.Value)
                {
                    data1.ID = number;
                    number += 1;
                }
                BindingListView<Data> binding = new BindingListView<Data>(Data1.Value);
                Data1.DataGrid.DataSource = binding;
            }
        }
        public BindingListView<Data> AddToListNewTask(Data data)
        {
            List<Data> list = Data1.Value;
            list.Add(data);
            Data1.Value = list;
            int number = 0;
            foreach (Data data1 in Data1.Value)
            {
                data1.ID = number;
                number += 1;
            }
            BindingListView<Data> binding = new BindingListView<Data>(Data1.Value);
            Data1.DataGrid.DataSource = binding;
            EditBackColor(Data1.DataGrid);
            return binding;
        }
        public BindingListView<Data> EditBackColor(DataGridView dataGridView1)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object w = row.Cells[3].Value;
                if (w != null)
                {
                    if (w.ToString() == "В процессе выполнения")
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.SkyBlue;
                        row.Cells[3].Style = style;
                    }
                    else if (w.ToString() == "Выполнено")
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.GreenYellow;
                        row.Cells[3].Style = style;
                    }
                    else if (w.ToString() == "Задача просрочена")
                    {
                        DataGridViewCellStyle style = new DataGridViewCellStyle();
                        style.BackColor = Color.Red;
                        row.Cells[3].Style = style;
                    }
                }
            }
            return null;
        }
        public void UpdateTable(DataGridView dataGridView)
        {
            int count = 0;
            List<Data> list;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (DateTime.Now > (DateTime)Data1.DataGrid[6, count].Value)
                {
                    Data1.DataGrid[3, count].Value = "Задача просрочена";
                    int index = (int)dataGridView[4, count].Value;
                    if (Data1.Value2 == null)
                    {
                        list = ListHistoryData;
                    }
                    else
                    {
                        list = Data1.Value2;
                    }
                    list.Add(Data1.Value[index]);
                    Data1.Value2 = list;
                    Data1.Value.RemoveAt(index);
                    int number = 0;
                    foreach (Data data1 in Data1.Value)
                    {
                        count = 0;
                        data1.ID = number;
                        number += 1;
                    }
                    BindingListView<Data> binding = new BindingListView<Data>(Data1.Value);
                    Data1.DataGrid.DataSource = binding;
                }
                count++;
            }
        }
        public void Message(DataGridView dataGridView)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DateTime tabledate = (DateTime)Data1.DataGrid[6, count].Value;
                TimeSpan tSpan = new TimeSpan(0, 1, 0, 0);
                DateTime result = tabledate - tSpan;
                if (DateTime.Now > tabledate)
                {
                    var dateTime = DateTime.Now;
                    MessageBox.Show($"Время задачи: {Data1.DataGrid[0, count].Value} истекло",
                        "Напоминание",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                }
                else if (result < DateTime.Now)
                {
                    var dateTime = DateTime.Now;
                    MessageBox.Show($"До конца задачи: {Data1.DataGrid[0, count].Value} \n" +
                        $"Oсталось {tabledate.Subtract(dateTime).Minutes} минут {tabledate.Subtract(dateTime).Seconds} секунд",
                        "Напоминание",
                    MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                }
                count++;
            }
        }
        public Data CreateData(TextBox textBox1,TextBox textBox2,DateTime date)
        {
            string title = textBox1.Text;
            string task = textBox2.Text;
            int id = Data1.Value.Count;
            DateTime dateStart = DateTime.Now;
            DateTime dateEnd = date;
            Data data = new Data(title, date, task, "В процессе выполнения", id, dateStart, dateEnd);
            return data;
        }
    }
}
