using System.Text;

namespace LatinRussianLanguageClassLib;

public class Translator
{
    public static string Translate(string text)
    {
        text = text.ToLower();

        StringBuilder translatedText = new(string.Empty);

        bool lastIsSoft = false;
        bool lastIsHard = false;
        bool lastIsSign = false;
        bool lastIsVowel = false;

        char last = ' ';

        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (Alphabet.Cyrillic.Contains(letter))
            {
                if (Alphabet.CyrillicConsonant.Contains(letter))
                {
                    if (letter == 'щ') translatedText.Append("š'");
                    else translatedText.Append(ConsonantTranslator[letter]);

                    if (letter == 'ч' || letter == 'й' || letter == 'щ') lastIsSoft = true;
                    if (letter == 'ш' || letter == 'ж' || letter == 'ц') lastIsHard = true;

                    lastIsSign = false;
                    lastIsVowel = false;
                }
                else if (Alphabet.CyrillicVowel.Contains(letter))
                {
                    if (letter == 'и' && lastIsHard) translatedText.Append(VowelTranslator['ы']);
                    else if (Alphabet.CyrillicSoftVowel.Contains(letter))
                    {
                        if (i == 0 || last == ' ' || lastIsSign || lastIsVowel) translatedText.Append('j').Append(VowelTranslator[letter]);
                        else if (lastIsSoft || last == 'ц') translatedText.Append(VowelTranslator[letter]);
                        else translatedText.Append('\'').Append(VowelTranslator[letter]);
                    }
                    else translatedText.Append(VowelTranslator[letter]);

                    lastIsVowel = true;

                    lastIsHard = false;
                    lastIsSoft = false;
                    lastIsSign = false;
                }
                else if (Alphabet.CyrillicSign.Contains(letter))
                {
                    if (lastIsSign) continue;
                    
                    if (letter == 'ь')
                    {
                        if (!lastIsHard && !lastIsSoft) translatedText.Append('\'');
                    }

                    lastIsSign = true;

                    lastIsHard = false;
                    lastIsSoft = false;
                    lastIsVowel = false;
                }
            }
            else translatedText.Append(letter);

            last = letter;
        }
        return translatedText.ToString();
    }

    private static readonly Dictionary<char, char> ConsonantTranslator = new()
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
    };

    private static readonly Dictionary<char, char> VowelTranslator = new()
    {
        {'а', 'a'},
        {'о', 'o'},
        {'у', 'u'},
        {'э', 'e'},
        {'ы', 'y'},
        {'и', 'i'},

        //soft
        {'е', 'e'},
        {'ё', 'o'},
        {'ю', 'u'},
        {'я', 'a'},
    };
}
