
using System.Numerics;

namespace Lesson12
{

    internal class Program
    {
        static PhoneBook _phoneBook;


        static void Main(string[] args)
        {
            _phoneBook = PhoneBook.ReadPhoneBookFile(args.Length == 0 ? "db.txt" : args[0]);

            while (true)
            {
                UserInteraction();
            }
        }
        static Person ReadPersonConsole()
        {
            Console.Write("Enter new last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter new first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter new Phone ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter new Birth");
            DateTime birth = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("uk-UA"));
            return new Person(lastName, firstName, phone, birth);
        }
        static void UserInteraction()
        {
            Console.WriteLine("1. Write all contacts");
            Console.WriteLine("2. Add new contact");
            Console.WriteLine("3. Edit contact");
            Console.WriteLine("4. Search by name");
            Console.WriteLine("5. Save");
            Console.Write("Enter a choice: ");

            uint input = 0;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    input = uint.Parse(Console.ReadLine());
                    tryAgain = false;
                }
                catch (FormatException)
                {
                    Console.Write("You`ve entered a wrong choice,please try again ");
                }
                catch (OverflowException)
                {
                    Console.Write("You suck at math a positive namber ");
                }
                catch (SystemException)
                {
                    Console.Write("Sorry,some sestem happened ");
                }
            }

            switch (input)
            {
                case 1:
                    var all = _phoneBook.GetAllContacts();
                    for (int i = 0; i < all.Length; ++i)
                    {
                        Console.WriteLine($"{i + 1}: {all[i]}");
                    }
                    break;
                case 2:
                    _phoneBook.AddNewContact(ReadPersonConsole());
                    break;
                case 3:
                    Console.Write("Enter a name to search for : ");
                    string name = Console.ReadLine();
                    Person newDate = ReadPersonConsole();
                    _phoneBook.EditContact(name, newDate);
                    break;
                case 4:
                    Console.Write("Enter a name to search for : ");
                    string query = Console.ReadLine();
                    Console.WriteLine( _phoneBook.SearchContactByQuery(query));
                    break;
                case 5:
                   _phoneBook.SaveToFile();
                    break;
                default:
                    Console.WriteLine("No such operation.");
                    break;
            }
        }

    }
}
