using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactList
{
    public class ContactManager
    {
        public static List<Contact> contacts = new List<Contact>();

        public Contact? Add(string name, List<string> phoneNumber, string email, string address)
        {
            int id = contacts.Count != 0 ? contacts[contacts.Count - 1].Id + 1 : 1 ;

            List<string> validNumbers = new List<string>();

            foreach(string number in phoneNumber)
            {
                if (!ValidateNumber(number))
                {
                    Console.WriteLine("Invalid phoneNumber: {0}", number);
                    
                }

                validNumbers.Add(number);
            }

            if(validNumbers.Count <= 0)
            {
                Console.WriteLine("Invalid phoneNumber");
                return null;
            }
            

            if (!ValidateEmail(email))
            {
                Console.WriteLine("Invalid email");
                return null;
            }

            var contact = new Contact
            {
                Id = id,
                Name = name,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email

            };
           
            contacts.Add(contact);
            return contact;
        }

        public void Delete(int id)
        {
            if(contacts.Exists(c => c.Id == id))
            {
                contacts.RemoveAt(id);
            }

            /*var contact = GetById(id);
            if(contact == null)
            {
                Console.WriteLine("Contact with ID: {0} not found", id);
            }
            contacts.Remove(contact);
            Console.WriteLine("Contact with ID: {0} successfully deleted", id);*/
        }

        public Contact? GetById(int id)
        {
            foreach(Contact contact in contacts)
            {
                if(contact.Id == id) return contact;
            }
            return null;
        }

        public void GetAll()
        {
            foreach(Contact contact in contacts)
            {
                Print(contact);
            }
        }

        public void Print(Contact c)
        {
            Console.WriteLine(c.ToString());

        }

        public Contact? Update(int id, string name, string address, string email)
        {
            var contact = GetById(id);
            if(contact == null)
            {
                Console.WriteLine("Contact with ID: {0} not found", id);
            }
            if (!ValidateEmail(email))
            {
                Console.WriteLine("Unable to update contact; Invalid email");
                return null;
            }
            contact.Address = address;
            contact.Email = email;
            contact.Name = name;

            return contact;
        }

        public Contact UpdatePhoneNumbers(int id, string number)
        {
            var contact = GetById(id);
            if (contact == null)
            {
                Console.WriteLine("Contact with ID: {0} not found", id);
            }
            if (!ValidateNumber(number))
            {
                Console.WriteLine("Unable to update contact; Invalid phone number");
                return null;
            }
            contact.PhoneNumber.Add(number);
            return contact;
        }

        public List<Contact> Search(String search)
        {
            return contacts.Where(c => c.Name.Contains(search) 
            || c.Email.Contains(search) || c.PhoneNumber.Contains(search)).ToList();


        }

        private bool ValidateNumber(string number)
        {
            if (number == null || number.Length < 11 || number.Length > 14 ) return false;

            string numberRegex = "((^+)(234){1}[0-9]{10})|((^234)[0-9]{10})|((^0)(7|8|9){1}(0|1){1}[0-9]{8})";

            return Regex.IsMatch(number, numberRegex);

        }

        private bool ValidateEmail(string email)
        {
            string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailRegex);
        }
    }
}
 