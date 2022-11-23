using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DAL.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}
