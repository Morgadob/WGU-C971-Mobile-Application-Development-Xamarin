using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Contacts.Classes
{
    public class Terms
    {
        [PrimaryKey, AutoIncrement] 
        public int TermID { get; set; }
        public string TermName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


    }
}
