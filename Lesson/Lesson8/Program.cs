

class Program
{
    static void Main()
    {
        Console.WriteLine(Compare("Hello", "Hello"));
        Console.WriteLine(Compare("Hello", "Hel"));
        Console.WriteLine(Analyze("Hello, world"));
        Console.WriteLine(Sort("Hello"));
        Console.WriteLine(Duplicates("Hello, world"));
    }

    static bool Compare(string a, string b)
    {
        if (a == null || b == null)
        {
            return false;
        }

        if (a.Length != b.Length)
        {
            return false;
        }

        for (int i = 0; i < a.Length; ++i)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }

        return true;
    }

    static (int letters, int digits, int separators, int punctuations) Analyze(string s)
    {
        int count_letter = 0;
        int count_digit = 0;
        int count_sep = 0;
        int count_pun = 0;

        foreach (char c in s)
        {
            if (char.IsLetter(c))
            {
                count_letter++;
            }
            else if (char.IsDigit(c))
            {
                count_digit++;
            }
            else if (char.IsSeparator(c))
            {
                count_sep++;
            }
            else if (char.IsPunctuation(c))
            {
                count_pun++;
            }
        }

        return (count_letter, count_digit, count_sep, count_pun);
    }

    static string Sort(string x)
    {
        char[] chars = x.ToLower().ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }

    static string Duplicates(string x)
    {
        string result = "";
        x = x.ToLower();
        for (int i = 0; i < x.Length; i++)
        {
            char y = x[i];
            if (x.IndexOf(y, i + 1) != -1)
            {
                if (!result.Contains(y.ToString()))
                {
                    result += y;
                }
            }
        }
        return result;
    }
}




