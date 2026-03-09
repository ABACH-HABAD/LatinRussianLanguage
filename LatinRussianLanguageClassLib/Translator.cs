using System.Diagnostics.Metrics;
using System.Text;

namespace LatinRussianLanguageClassLib;

public class Translator
{
    public static string Translate(string text)
    {
        StringBuilder translatedText = new(string.Empty);

        char last = ' ';

        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (letter.IsCyrillic())
            {
                if (letter.IsConsonant()) ProcessConsonant(letter, translatedText);
                else if (letter.IsVowel()) ProcessVowel(letter, last, translatedText);
                else if (letter.IsSign()) ProcessSign(letter, last, translatedText);
            }
            else translatedText.Append(letter);

            last = letter;
        }
        return translatedText.ToString();
    }

    private static void ProcessConsonant(char consonant, StringBuilder output)
    {
        output.Append(Alphabet.Consonant[consonant]);
        if (consonant == 'щ' || consonant == 'Щ') output.Append('\'');
    }

    private static void ProcessVowel(char vowel, char previous, StringBuilder output)
    {
        if ((vowel == 'и' || vowel == 'И') && previous.IsAlwaysHardConsonant()) vowel = char.IsUpper(vowel) ? 'Ы' : 'ы';

        if (vowel.IsSoftVowel())
        {
            if (char.IsWhiteSpace(previous) || previous.IsVowel() || previous.IsSign())
            {
                output.Append(char.IsUpper(vowel) ? 'J' : 'j');
                if (char.IsUpper(vowel)) vowel = char.ToLower(vowel);
            }
            else if (!(previous.IsAlwaysSoftConsonant() || previous.IsAlwaysHardConsonant())) output.Append('\'');
        }

        output.Append(Alphabet.Vowel[vowel]);
    }

    private static void ProcessSign(char sign, char previous, StringBuilder output)
    {
        if (previous.IsSign()) return;

        if (sign == 'ь')
        {
            if (!sign.IsAlwaysHardConsonant() && !previous.IsAlwaysSoftConsonant()) output.Append('\'');
        }
    }
}