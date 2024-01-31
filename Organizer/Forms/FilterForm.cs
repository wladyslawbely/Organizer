using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Organizer.Forms
{
    public partial class FilterForm : Form
    {
        readonly BusinessLogic businessLogic = new BusinessLogic();
        public FilterForm()
        {
            InitializeComponent();
        }
        private DateTime date1, date2;
        private void label7_Click(object sender, EventArgs e)
        {
            BindingListView<Data> binding1 = new BindingListView<Data>(Data1.Value2);
            Data1.DataGrid2.DataSource = binding1;
            businessLogic.EditBackColor(Data1.DataGrid2);
            List<Data> Data = new List<Data>();
            int count = 0;
            try
            {
                date1 = DateTime.ParseExact(businessLogic.Time(dateTimePicker1, numericUpDown1.Value, numericUpDown2.Value), "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);       
                date2 = DateTime.ParseExact(businessLogic.Time(dateTimePicker2, numericUpDown3.Value, numericUpDown4.Value), "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (date1 < date2)
                        {
                            foreach (DataGridViewRow row in Data1.DataGrid2.Rows)
                            {
                                if ((DateTime)row.Cells[5].Value > date1 && (DateTime)row.Cells[5].Value < date2)
                                {
                                    Data.Add(Data1.Value2[count]);
                                }
                                count++;
                            }
                            BindingListView<Data> binding = new BindingListView<Data>(Data);
                            Data1.DataGrid2.DataSource = binding;
                            businessLogic.EditBackColor(Data1.DataGrid2);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Данные введены некорректно",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                        }
                        break;

                    case 1:
                        if (date1 < date2)
                        {
                            foreach (DataGridViewRow row in Data1.DataGrid2.Rows)
                            {
                                if ((DateTime)row.Cells[6].Value > date1 && (DateTime)row.Cells[6].Value < date2)
                                {
                                    Data.Add(Data1.Value2[count]);
                                }
                                count++;
                            }
                            BindingListView<Data> binding = new BindingListView<Data>(Data);
                            Data1.DataGrid2.DataSource = binding;
                            businessLogic.EditBackColor(Data1.DataGrid2);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Данные введены некорректно",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                        }
                        break;
                    case 2:
                        if (date1 < date2)
                        {
                            foreach (DataGridViewRow row in Data1.DataGrid2.Rows)
                            {
                                if ((DateTime)row.Cells[1].Value > date1 && (DateTime)row.Cells[1].Value < date2)
                                {
                                    Data.Add(Data1.Value2[count]);
                                }
                                count++;
                            }
                            BindingListView<Data> binding = new BindingListView<Data>(Data);
                            Data1.DataGrid2.DataSource = binding;
                            businessLogic.EditBackColor(Data1.DataGrid2);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Данные введены некорректно",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                        }
                        break;
                    case 3:
                        if (date1 < date2)
                        {
                            foreach (DataGridViewRow row in Data1.DataGrid2.Rows)
                            {
                                if ((DateTime)row.Cells[5].Value > date1 && (DateTime)row.Cells[6].Value < date2)
                                {
                                    Data.Add(Data1.Value2[count]);
                                }
                                count++;
                            }
                            BindingListView<Data> binding = new BindingListView<Data>(Data);
                            Data1.DataGrid2.DataSource = binding;
                            businessLogic.EditBackColor(Data1.DataGrid2);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Данные введены некорректно",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                        }
                        break;
                    default:
                        MessageBox.Show("Не выбран способ фильтрации",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
            }
        }
    }
}
