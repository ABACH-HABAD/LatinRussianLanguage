namespace LatinRussianLanguageClassLib;

public static class Alphabet
{
    public static bool IsCyrillic(this char letter)
    {
        return (letter >= 'а' && letter <= 'я') || (letter >= 'А' && letter <= 'Я') || letter == 'ё' || letter == 'Ё';
    }
    public static bool IsConsonant(this char letter)
    {
        return Consonant.ContainsKey(letter);
    }
    public static bool IsAlwaysHardConsonant(this char letter)
    {
        return letter == 'ц' || letter == 'Ц' || letter == 'ш' || letter == 'Ш' || letter == 'ж' || letter == 'Ж';
    }
    public static bool IsAlwaysSoftConsonant(this char letter)
    {
        return letter == 'й' || letter == 'Й' || letter == 'ч' || letter == 'Ч' || letter == 'щ' || letter == 'Щ';
    }
    public static bool IsSoftVowel(this char letter)
    {
        return letter == 'е' || letter == 'Е' || letter == 'ё' || letter == 'Ё' || letter == 'ю' || letter == 'Ю' || letter == 'я' || letter == 'Я';
    }
    public static bool IsVowel(this char letter)
    {
        return Vowel.ContainsKey(letter);
    }
    public static bool IsSign(this char letter)
    {
        return letter == 'ь' || letter == 'ъ';
    }

    internal static readonly Dictionary<char, char> Consonant = new()
    {
        {'б', 'b'},
        {'в', 'v'},
        {'г', 'g'},
        {'д', 'd'},
        {'ж', 'ž'},
        {'з', 'z'},
        {'й', 'j'},
        {'к', 'k'},
        {'л', 'l'},
        {'м', 'm'},
        {'н', 'n'},
        {'п', 'p'},
        {'р', 'r'},
        {'с', 's'},
        {'т', 't'},
        {'у', 'u'},
        {'ф', 'f'},
        {'х', 'h'},
        {'ц', 'c'},
        {'ч', 'č'},
        {'ш', 'š'},
        {'щ', 'š'},

        {'Б', 'B'},
        {'В', 'V'},
        {'Г', 'G'},
        {'Д', 'D'},
        {'Ж', 'Ž'},
        {'З', 'Z'},
        {'Й', 'J'},
        {'К', 'K'},
        {'Л', 'L'},
        {'М', 'M'},
        {'Н', 'N'},
        {'П', 'P'},
        {'Р', 'R'},
        {'С', 'S'},
        {'Т', 'T'},
        {'У', 'U'},
        {'Ф', 'F'},
        {'Х', 'H'},
        {'Ц', 'C'},
        {'Ч', 'Č'},
        {'Ш', 'Š'},
        {'Щ', 'Š'},
    };

    internal static readonly Dictionary<char, char> Vowel = new()
    {
        {'а', 'a'},
        {'о', 'o'},
        {'у', 'u'},
        {'э', 'e'},
        {'ы', 'y'},
        {'и', 'i'},

        {'А', 'A'},
        {'О', 'O'},
        {'У', 'U'},
        {'Э', 'E'},
        {'Ы', 'Y'},
        {'И', 'I'},

        //soft
        {'е', 'e'},
        {'ё', 'o'},
        {'ю', 'u'},
        {'я', 'a'},

        {'Е', 'E'},
        {'Ё', 'O'},
        {'Ю', 'U'},
        {'Я', 'A'},
    };
}
