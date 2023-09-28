namespace Lesson12
{
    class PhoneBook
    {

        private string _phoneBookFile; //приватні поля прийнятописати через _
        private Person[] _contacts;
        public PhoneBook(string file)
        {
            _phoneBookFile = file;
            _contacts = new Person[0];
        }

        public void AddNewContact(Person newPerson)
        {
            Array.Resize(ref _contacts, _contacts.Length + 1); //ref аргумент передається по ссилці
            _contacts[^1] = newPerson;
        }
        public bool EditContact(string name, Person newPerson)
        {
            int contactIndex = ContatctIndex(name);
            if (contactIndex < 0)
            {
                return false;
            }
            _contacts[contactIndex] = newPerson;
            return true;
        }

        public bool DeleteContatct(string name)
        {
            int contactIndex = ContatctIndex(name);
            if (contactIndex < 0)
            {
                return false;
            }
            Person[] contactsCopy = new Person[_contacts.Length];
            Array.Copy(_contacts, contactsCopy, _contacts.Length);
            _contacts = new Person[_contacts.Length - 1];//Зменшив на 1
            Array.Copy(contactsCopy, 0, _contacts, 0, contactIndex);// зкопіював до індексу що знайшли
            Array.Copy(contactsCopy, contactIndex + 1, _contacts, contactIndex, _contacts.Length - contactIndex);//зкопіював після індексу що знайшли
            return true;
        }

        public Person[] GetAllContacts() => _contacts;

        public Person SearchContactByQuery(string query) => _contacts[ContatctIndex(query)];
        private int ContatctIndex(string name)
        {
            try
            {

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

            var contactsNew = new Person[_contacts.Length + 1];

            for (var i = 0; i < _contacts.Length; i++)
            {
                contactsNew[i] = _contacts[i];
                foreach (var contact in contactsNew)
                {
                    if (name == contactsNew[i].FirstName || name == contactsNew[i].LastName)
                    {
                        return i;
                    }
                    break;
                }
            }
            return -1;
        }
        public bool SaveToFile()
        {
            try
            {
                string[] lines = new string[_contacts.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_contacts[i].FullName},{_contacts[i].Phone},{_contacts[i].BirthDate}";
                }
                File.WriteAllLines(_phoneBookFile, lines);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static PhoneBook ReadPhoneBookFile(string fileName)
        {
            string[] lines = ReadDatabaseAllTextLines(fileName);
            return new PhoneBook(fileName)
            {
                _contacts = ConvertStringsToContacts(lines),
            };
        }
        private static string[] ReadDatabaseAllTextLines(string file)
        {
            try
            {
                return File.ReadAllLines(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new string[0];
            }
        }
        private static Person[] ConvertStringsToContacts(string[] records)
        {

            var contacts = new Person[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(',');
                if (array.Length != 1)
                {
                    contacts[i] = new Person(array[0], array[1], array[2], DateTime.Parse(array[3]));
                }

            }
            return contacts;
        }
    }
}
