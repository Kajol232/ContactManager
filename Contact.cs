using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class Contact
    {   
        public int Id {  get; set; }
        public string Name { get; set; }
        public List<string> PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return "Id:" + Id + "\n" 
                + "Name: " + Name + "\n"
                + "Contact: " + printNumbers() + "\n"
                + "Email Address: " + Email;
        }

        private string printNumbers()
        {
            StringBuilder sb = new StringBuilder();
             foreach(string number in this.PhoneNumber)
             {
                sb.Append(number);
                sb.Append(", ");

             }

             return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Contact)) return false;

            return this.Name == ((Contact) obj).Name
                &&this.PhoneNumber == ((Contact) obj).PhoneNumber;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.PhoneNumber.GetHashCode();
        }

        
    }


}
