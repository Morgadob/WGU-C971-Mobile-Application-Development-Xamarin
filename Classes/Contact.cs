using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Contacts.Classes
{
    public class Contact
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }


        public string Lastname { get; set; }

        public string Email { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

    }
}
