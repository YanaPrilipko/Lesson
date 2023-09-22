using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Linq;
using System.Globalization;
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
                /*try
                {
                    UserInteraction();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Sorry, some error:{ex.Message} \n{ex.StackTrace}");
                }*/

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

            //int input = int.Parse(Console.ReadLine());
            uint input = 0;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    input = uint.Parse(Console.ReadLine());
                    tryAgain = false;
                }
                catch(FormatException)
                {
                    Console.Write("You`ve entered a wrong choice,please try again ");
                    //throw ex;
                }
                catch (OverflowException)
                {
                    Console.Write("You suck at math a positive namber ");
                    //throw ex;
                }
                catch (SystemException)
                {
                    Console.Write("Sorry,some sestem happened ");
                    //throw ex;
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
            Console.WriteLine("Enter new Name ");
            string name = Console.ReadLine();

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

            var contactsNew = new (string name, string phone, DateTime date)[contacts.Length + 1];

            for (var i = 0; i < contacts.Length; i++)
            {
                contactsNew[i] = contacts[i];
            }

            contactsNew[contacts.Length].name = name;
            contactsNew[contacts.Length].phone = phone;
            contactsNew[contacts.Length].date = birth;
            contacts = contactsNew;
            SaveContactsToFile();
        }
        static void EditContact()
        {
            int Index = SearchContatct();

            Console.WriteLine("Enter new Name");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter new Phone");
            string phone1 = Console.ReadLine();

            DateTime birth1 = DateTime.Now;
            try
            {
                Console.WriteLine("Enter new Birth");
                birth1 = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("uk-UA"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, wrong format.");
            }

            Console.WriteLine("Are you sure you want to edit the data? True or False");
            bool answer = Convert.ToBoolean(Console.ReadLine());

            if (answer == true)
            {
                contacts[Index].name = name1;
                contacts[Index].phone = phone1;
                contacts[Index].birth = birth1;
            }

        }

        static int SearchContatct()
        {
/*            Console.WriteLine("Enter a name to search for");
            string name = Console.ReadLine();*/
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
                int age = DateTime.Now.Year - contacts[i].birth.Year; 
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
            try
            {
                string[] lines = new string[contacts.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{contacts[i].Item1},{contacts[i].Item2},{contacts[i].Item3}";
                }
                File.AppendAllLines("database ", lines);
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
            catch (DirectoryNotFoundException ex )
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



