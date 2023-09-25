using System.Numerics;
using System.Xml.Linq;

namespace Lesson11
{
    class Person
    {
        public const string UnknownPersonName = "Noname";
        private string _firstName;//field - поля
        public string FirstName//property full властивість
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value == null ? UnknownPersonName : value;
            }
        }
        public string LastName { get; set; }//property short
        public string Phone { get; set; }//property
        public DateTime BirthDate { get; init; }

        public Person(Person otherPerson,string newFirstName = null, string newLastName = null, string newPhone = null, DateTime? newBirthDate = null) //копіюючий кончтруктор 
        {
            FirstName = newFirstName ?? otherPerson.FirstName; // null coalescent operator
            LastName = newLastName ?? otherPerson.LastName;
            Phone = newPhone ?? otherPerson.Phone;
            BirthDate = newBirthDate ?? otherPerson.BirthDate;
        }
        public Person()
        {
        }
    }


        internal class Program
    {
        static string database = "db.txt";
        static Person[] contacts;

        static void Main()
        {
            string[] records = ReadDatabaseAllTextLines(database);
            contacts = ConvertStringsToContacts(records);

            while (true)
            {
                UserInteraction();
            }
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
                    WriteAllContactsToConsole();
                    break;
                case 2:
                    AddNewContact();
                    break;
                case 3:
                    EditContact();
                    break;
                case 4:
                    SearchContatct();
                    break;
                case 5:
                    SaveContactsToFile();
                    break;
                default:
                    Console.WriteLine("No such operation.");
                    break;
            }
        }

        static void AddNewContact()
        {
            Console.Write("Enter new first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter new last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter new Phone ");
            string phone = Console.ReadLine();
            DateTime birth = DateTime.Now;
            try
            {
                Console.WriteLine("Enter new Birth");
                birth = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("uk-UA"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, wrong format");
            }

            Person person = new Person() //instatiation
            {
                BirthDate = birth,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
            };
            Array.Resize(ref contacts, contacts.Length + 1); //ref аргумент передається по ссилці
            contacts[^1] = person;
        }
        static void EditContact()
        {
            int Index = SearchContatct();

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter new Phone");
            string phone = Console.ReadLine();

            DateTime birth = DateTime.Now;
            try
            {
                Console.WriteLine("Enter new Birth");
                birth = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("uk-UA"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, wrong format.");
            }

            Console.WriteLine("Are you sure you want to edit the data? True or False");
            bool answer = Convert.ToBoolean(Console.ReadLine());

            if (answer == true)
            {
                contacts[Index] = new Person(contacts[Index], firstName, lastName, phone, birth);
            }
            

        }

        static int SearchContatct()
        {
            string name = "";
            try
            {
                Console.Write("Enter a name to search for : ");
                name = Console.ReadLine();

                if (name == null || name.Length < 2)
                {
                    throw new Exception("You entered an incorrect name");

                }
                else
                {
                    Console.WriteLine($"You entered a name: {name}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            var contactsNew = new Person[contacts.Length + 1];

            for (var i = 0; i < contacts.Length; i++)
            {
                contactsNew[i] = contacts[i];
                foreach (var contact in contactsNew)
                {
                    if (name == contactsNew[i].FirstName || name == contactsNew[i].LastName)
                    {
                        int age = DateTime.Now.Year - contactsNew[i].BirthDate.Year;
                        Console.WriteLine($"#{i + 1}: Name: {contacts[i].FirstName} {contacts[i].LastName}, Phone: {contacts[i].Phone}, Age: {age}");
                        return i;
                    }
                    break;
                }
            }
            return 0;
        }

        static void WriteAllContactsToConsole()
        {
            for (int i = 0; i < contacts.Length; i++)
            {
                int age = DateTime.Now.Year - contacts[i].BirthDate.Year;
                Console.WriteLine($"#{i + 1}: Name: {contacts[i].FirstName} {contacts[i].LastName}, Phone: {contacts[i].Phone}, Age: {age}");
            }
        }

        static Person[] ConvertStringsToContacts(string[] records)
        {

            var contacts = new Person[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(',');
                if (array.Length != 3)
                {
                    Console.WriteLine($"Line #{i + 1}: {records[i]} cannot be parsed");
                    continue;
                }
                contacts[i] = new Person
                {
                    FirstName = array[0],
                    LastName = Person.UnknownPersonName,
                    Phone = array[1],
                    BirthDate = DateTime.Parse(array[2]),
                };
            }
            return contacts;
        }


        static void SaveContactsToFile()
        {
            try
            {
                string[] lines = new string[contacts.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{contacts[i].FirstName} {contacts[i].LastName},{contacts[i].Phone},{contacts[i].BirthDate}";
                }
                File.WriteAllLines("database ", lines);
            }

            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Error: directory not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Input or output error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string[] ReadDatabaseAllTextLines(string file)
        {
            try
            {
                return File.ReadAllLines(file);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Error: directory not found: {ex.Message}");
                return new string[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new string[0];
            }
        }
    }
}

