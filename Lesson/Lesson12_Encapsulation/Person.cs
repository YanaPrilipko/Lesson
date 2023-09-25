namespace Lesson12
{
    record Person(string FirstName, string LastName, string Phone, DateTime BirthDate)
    {
        public string FullName => $"{FirstName} {LastName}"; // CamelCase

        public override string ToString() => $"{FullName}, {Phone}, {BirthDate:dd.mm.yyyy}";
    }
}
