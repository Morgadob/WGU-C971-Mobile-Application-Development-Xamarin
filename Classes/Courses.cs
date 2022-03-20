using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Contacts.Classes
{
    public class Courses
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }

        public int TermID { get; set; }
        
        public string CourseName { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorEmail { get; set; }
        public string Notes { get; set; }
        public bool NotificationEnabled { get; set; }

    }
}
