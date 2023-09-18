
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;

namespace Lesson9
{
    internal class Program
    {
        static string database = "db.txt";
        static (string name, string phone, DateTime birth)[] contacts;

        static void Main()
        {

            // 0. SAVE IT TO THE FILE WITH ".CSV"
            // 1. Writes to console currently available contacts in the file
            // 2. Add new contact
            // 3. Edit contact
            // 4. Search contacts
            // 5. Calculates the contact age
            // 6. Save database


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

            int input = int.Parse(Console.ReadLine());
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
            Console.WriteLine("Enter new Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new Phone ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter new Birth ");
            string birth = Console.ReadLine();
            var birthTest = DateTime.Parse(birth);

            var contactsNew = new (string name, string phone, DateTime date)[contacts.Length + 1];
            
            for(var i = 0; i < contacts.Length; i++)
            {
                contactsNew[i] = contacts[i];
            }
            contactsNew[contacts.Length].name = name;
            contactsNew[contacts.Length].phone = phone;
            contactsNew[contacts.Length].date = birthTest;
            contacts = contactsNew;
            SaveContactsToFile();
        }
        static void EditContact()
        {
            SearchContatct();
            Console.WriteLine("Enter new Name");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter new Phone");
            string phone1 = Console.ReadLine();
            Console.WriteLine("Enter new Birth");
            string birth = Console.ReadLine();
            var birth1 = DateTime.Parse(birth);

            contacts[Index].name = name1;
            contacts[Index].phone = phone1;
            contacts[Index].birth = birth1;

        }
        static int Index;
        static void SearchContatct()
        {
            Console.WriteLine("Enter a name to search for");
            string name = Console.ReadLine();

            var contactsNew = new (string name, string phone, DateTime date)[contacts.Length + 1];

            for (var i = 0; i < contacts.Length; i++)
            {
                contactsNew[i] = contacts[i];
                foreach (var contact in contactsNew)
                {
                    if (name == contactsNew[i].name)
                    {
                        int age = DateTime.Now.Year - contactsNew[i].date.Year; 
                        Console.WriteLine($"#{i + 1}: Name: {contactsNew[i].Item1}, Phone: {contactsNew[i].Item2}, Age: {age}");
                        Index = i;
                    }
                    break;
                }
            }
        }

        static void WriteAllContactsToConsole()
        {
            for (int i = 0; i < contacts.Length; i++)
            {
                int age = DateTime.Now.Year - contacts[i].birth.Year; // підрахунок років
                Console.WriteLine($"#{i + 1}: Name: {contacts[i].Item1}, Phone: {contacts[i].Item2}, Age: {age}");
            }
        }

        static (string name, string phone, DateTime date)[] ConvertStringsToContacts(string[] records)
        {

            var contacts = new (string name, string phone, DateTime date)[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(',');
                if (array.Length != 3)
                {
                    Console.WriteLine($"Line #{i + 1}: {records[i]} cannot be parsed");
                    continue;
                }
                contacts[i].name = array[0];
                contacts[i].phone = array[1];
                contacts[i].date = DateTime.Parse(array[2]);
            }
            return contacts;
        }

        static void SaveContactsToFile()
        {
            string[] lines = new string[contacts.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{contacts[i].Item1},{contacts[i].Item2},{contacts[i].Item3}";
            }
            File.WriteAllLines(database, lines);
        }

        static string[] ReadDatabaseAllTextLines(string file) 
        {
            if (!File.Exists(file))
            {
                File.WriteAllText(file, "");
            }
            return File.ReadAllLines(file);
        }
    }
}




