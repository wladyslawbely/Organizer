using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer.Forms
{
    public partial class CreateTaskForm : Form
    {
        public CreateTaskForm()
        {
            InitializeComponent();
        }
        private DateTime date;
        readonly BusinessLogic business = new BusinessLogic();
        readonly Checking checking = new Checking();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                date = DateTime.ParseExact(business.Time(dateTimePicker, numericUpDown1.Value, numericUpDown2.Value), "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                if (date < DateTime.Now)
                {
                    MessageBox.Show(
                        "Эта дата уже прошла",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (!checking.CheckingEmpty(textBox1,textBox2))
                    {
                        MessageBox.Show("Данные не введены",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                    }
                    while (checking.CheckingEmpty(textBox1, textBox2))
                    {
                        business.AddToListNewTask(business.CreateData(textBox1, textBox2, date));
                        this.Close();
                    }
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
