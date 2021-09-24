using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developers
{
    public class Developer
    {
        public Developer() { }
        public Developer(string firstName, string lastName, bool hasPluralSightAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            HasPluralSightAccess = hasPluralSightAccess;
        }

        public int iD { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + LastName; } }
        public bool HasPluralSightAccess { get; set;}
    }
}
