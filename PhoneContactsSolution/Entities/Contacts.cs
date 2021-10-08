using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contacts
    {

        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneNumber3 { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Lastname);
        }

    }
}
