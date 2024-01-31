using System;
using System.Xml.Serialization;

namespace Organizer
{
    public class Data 
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
        
        [XmlIgnore]
        public int ID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }

        public Data()
        { }

        public Data(string title, DateTime date, string task, string status,
            int iD,DateTime dateStart, DateTime dateFinish)
        {
            Title = title;
            Date = date;
            Task = task;
            Status = status;
            ID = iD;
            DateStart = dateStart;
            DateFinish = dateFinish;
        }
    }
}