using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer.Forms
{
    public partial class EditTaskForm : Form
    {
        private DateTime time;
        readonly BusinessLogic businessLogic = new BusinessLogic();
        private void Form3_Load(object sender, EventArgs e)
        {
            var index = Data1.Index;
            textBox1.Text = Data1.Value[index].Task;
            textBox2.Text = Data1.Value[index].Title;
            time = Data1.Value[index].Date;
            textBox3.Text = time.ToString();
        }

        public EditTaskForm()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Data1.DataGrid[0, Data1.TableIndex].Value = textBox2.Text;
            Data1.DataGrid[1, Data1.TableIndex].Value = textBox3.Text;
            Data1.DataGrid[2, Data1.TableIndex].Value = textBox1.Text;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
            MessageBox.Show("Точно удалить эту задачу?",
                           "Подтверждение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                businessLogic.DeleteTask(Data1.DataGrid);
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
            MessageBox.Show("Задача выполнена?",
                           "Подтверждение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                Data1.DataGrid[3, Data1.TableIndex].Value = "Выполнено";
                Data1.DataGrid[6, Data1.TableIndex].Value = DateTime.Now;
                businessLogic.AddToHistoryData(Data1.DataGrid);
                businessLogic.EditBackColor(Data1.DataGrid);
                this.Close();
            }
        }
    }
}