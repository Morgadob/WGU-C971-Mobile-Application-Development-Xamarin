using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Contacts.Classes
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement] 
        public int AssessmentID { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool NotificationEnabled { get; set; }

    }
}
