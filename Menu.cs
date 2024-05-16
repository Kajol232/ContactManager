using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class Menu
    {
        private readonly MenuAssistance assistance = new MenuAssistance();

        public void MainMenu()
        {
            bool showMenu = true;

            while (showMenu)
            {
                ShowMenu();
                Console.WriteLine("Select an option");

                int input = CaptureInput();

                switch (input)
                {
                    case 0:
                        showMenu = false;
                        Console.WriteLine("Thank you");
                        break;
                    case 1:
                        assistance.AddContact();
                        HookScreen();
                        break;
                    case 2:
                        assistance.ViewContact();
                        HookScreen();
                        break;
                    case 3:
                        assistance.UpdateContactInfo();
                        HookScreen();
                        break;
                    case 4:
                        assistance.AddNumber();
                        HookScreen();
                        break;
                    case 5:
                        assistance.Delete();
                        HookScreen();
                        break;
                    case 6:
                        assistance.ViewContacts();
                        HookScreen();
                        break;
                    case 7:
                        assistance.SearchContact();
                        HookScreen();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected, please select between 0 and 6");
                        break;
                }
            }

        }
        private static void ShowMenu()
        {          
            Console.Clear();
            Console.WriteLine("Select Option to Perform an Operation");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contact Information");
            Console.WriteLine("3. Update Contact Information");
            Console.WriteLine("4. Add Number to Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. View Contact List");
            Console.WriteLine("7. Search Contact");
            Console.WriteLine("0. Exit");
        }

        private static int CaptureInput()
        {
            Console.WriteLine("Input a number");
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
        private static void HookScreen()
        {
            Console.WriteLine("Press enter key to continue...");
            Console.ReadKey();
        }
    }
}
