using Organizer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OrganizerForm());
        }
    }
    public static class Data1
    {
        public static List<Data> Value { get; set; }
        public static List<Data> Value2 { get; set; }
        public static DataGridView DataGrid { get; set; }
        public static DataGridView DataGrid2 { get; set; }
        public static int Index { get; set; }
        public static int TableIndex { get; set; }
    }
}
