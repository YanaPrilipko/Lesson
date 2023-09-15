

using Lesson8;

//Compare
string str1 = "Hello World";
string str2 = "Hello World";
string str3 = "Hello Friend";
Console.WriteLine(String.Equals(str1, str2));
Console.WriteLine(String.Equals(str1, str3));

Console.WriteLine(str1 == str2);
Console.WriteLine(str1 == str3);

//Analyze
string str = @"Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method
Analyze that will return number of alphabetic chars in string, digits and another special characters
Sort that will return string that contains all characters from input string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo')
Duplicate that will return array of characters that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l'])";
Console.WriteLine("Введите символ:");
string s = Console.ReadLine();
int count = str.ToCharArray().Where(c => c == s[0]).Count();
Console.WriteLine(count);
Console.ReadKey();

//Sort 
string a = "Bonyaa";
string b = a.ToLower();
b = string.Concat(b.OrderBy(ch => ch));

Console.WriteLine(b);


//Duplicate
Dublicate.Main();


