namespace LatinRussianLanguageClassLib;

public static class Alphabet
{
    public static string Cyrillic { get; } = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
    public static string CyrillicConsonant { get; } = "бвгджзйклмнпрстфхцчшщ";
    public static string CyrillicVowel { get; } = "аеёиоуыэюя";
    public static string CyrillicSoftVowel { get; } = "еёюя";
    public static string CyrillicSign { get; } = "ьъ";
}
