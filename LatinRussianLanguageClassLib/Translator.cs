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
                if (letter.IsConsonant())
                {
                    translatedText.Append(Alphabet.Consonant[letter]);
                    if (letter == 'щ') translatedText.Append('\'');
                }
                else if (letter.IsVowel())
                {
                    if (letter == 'и' && last.IsAlwaysHardConsonant()) letter = 'ы';

                    if (letter.IsSoftVowel())
                    {
                        if (i == 0 || char.IsWhiteSpace(last))
                        {
                            translatedText.Append(char.IsUpper(letter) ? 'J' : 'j');
                            letter = char.ToLower(letter);
                        }
                        else if (last.IsSign() || last.IsVowel()) translatedText.Append('j');
                        else if (!(last.IsAlwaysSoftConsonant() || last.IsAlwaysHardConsonant())) translatedText.Append('\'');
                    }

                    translatedText.Append(Alphabet.Vowel[letter]);
                }
                else if (letter.IsSign())
                {
                    if (last.IsSign()) continue;

                    if (letter == 'ь')
                    {
                        if (!last.IsAlwaysHardConsonant() && !last.IsAlwaysSoftConsonant()) translatedText.Append('\'');
                    }
                }
            }
            else translatedText.Append(letter);

            last = letter;
        }
        return translatedText.ToString();
    }
}