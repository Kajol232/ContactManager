using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class MenuAssistance
    {
        private readonly ContactManager manager = new ContactManager();
        public void AddContact()
        {
            Console.WriteLine("Enter contact name");
            string name = Console.ReadLine();

            int numOfContact = CaptureInput("Enter No of PhoneNumbers Contact has");
            List<string> phoneNumbers = new List<string>();
            int count = 1;
            while(numOfContact > 0)
            {
                Console.WriteLine("Input Phone Number{0}", count);
                phoneNumbers.Add(Console.ReadLine());
                count++;
                numOfContact--;
            }

            Console.WriteLine("Enter contact address");
            string address = Console.ReadLine();

            Console.WriteLine("Enter contact email");
            string email = Console.ReadLine();

            if(manager.Add(name, phoneNumbers, email, address) != null)
            {
                Console.WriteLine("Contact added successfully");
            }
            else
            {
                Console.WriteLine("Unable to add contact");
            }


        }

        public void ViewContact()
        {
            int contactId = CaptureInput("Enter Contact Id");

            Contact c = manager.GetById(contactId);

            if(c != null)
            {
                manager.Print(c);
            }
        }

        public void UpdateContactInfo()
        {
            int contactId = CaptureInput("Enter Contact Id");

            Contact c = manager.GetById(contactId);
            if(c != null)
            {
                Console.WriteLine("Enter contact name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter contact address");
                string address = Console.ReadLine();

                Console.WriteLine("Enter contact email");
                string email = Console.ReadLine();

                if(manager.Update(contactId, name, address, email) != null)
                {
                    Console.WriteLine("Contact updated successfully");
                }
                else
                {
                    Console.WriteLine("Unable to update contact");
                }

            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void AddNumber()
        {
            int contactId = CaptureInput("Enter Contact Id");

            Contact c = manager.GetById(contactId);
            if (c != null)
            {
                Console.WriteLine("Input Contact new Phone Number");
                string number = Console.ReadLine();
                if(manager.UpdatePhoneNumbers(contactId, number) != null)
                {
                    Console.WriteLine("Contact number updated successfully");
                }
                else { Console.WriteLine("Unable to update number"); }
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void Delete()
        {
            int contactId = CaptureInput("Enter Contact Id");

            Contact c = manager.GetById(contactId);

            if (c != null)
            {
                manager.Delete(contactId);
            }

        }

        public void ViewContacts()
        {
            manager.GetAll();
        }

        public void SearchContact()
        {
            Console.WriteLine("Enter filter key; can be name, email or phone number");
            string searchKey = Console.ReadLine();

            var result = manager.Search(searchKey);

            if (result != null)
            {
                foreach( Contact contact in result )
                {
                    manager.Print(contact);
                }
            }else {
                Console.WriteLine("No result found for search key: {0}", searchKey); 
            }

        }

        private static int CaptureInput(string message)
        {
            Console.WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input, Only numbers are allowed");
            }
            return 0;
        }
      
    }
}
