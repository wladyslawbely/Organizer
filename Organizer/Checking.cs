using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public class Checking
    {
        BusinessLogic businessLogic = new BusinessLogic();
        public void CheckingFile()
        {
            try
            {
                if (new FileInfo("Data.xml").Length == 0)
                {
                    businessLogic.WriteToFile();
                }
            }
            catch
            {
                File.Create("Data.xml").Close();
                businessLogic.WriteToFile();
            }
            businessLogic.ReadFromFile();

            try
            {
                if (new FileInfo("DataHistory.xml").Length == 0)
                {
                    businessLogic.WriteToFileHistory();
                }
            }
            catch
            {
                File.Create("DataHistory.xml").Close();
                businessLogic.WriteToFileHistory();
            }
            businessLogic.ReadFromFileHistory();
        }

        public bool CheckingEmpty(TextBox textBox1, TextBox textBox2)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                return false;
            else
                return true;
        }
    }
}
