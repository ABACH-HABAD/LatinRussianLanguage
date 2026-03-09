# LatinRussianLanguage
##Здраствуй дорогой друг / Zdravstvuj dorogoj drug
##Давай на секунду представим как бы выглядел русский язык, если бы вместо кириллической письменности, использовалась латинская.
Для составления нового алфавита использовался принцип одна буква – один звук, так, например В – это V, Г – это G, а Д – это D и так далее по алфавиту. Буквы Ч, Ш, Ж были заимствованы из других славянских языков, использующих латинскую письменность, и обозначаются как Č, Š и Ž соответственно. Для обозначения мягкости согласных был выбран символ ‘ (апостроф). Буква Щ обозначается как мягкая Ш, то есть Š’. Гласные буквы, которые раскладываются на два звука, записываются двумя буквами, например Я – JA, где J – это Й. После согласных, не имеющих мягкую форму (таких как Ц, Ш и Ж) буква И заменяется на Ы, чтобы не создавать путаницу при чтении.  
Данная программа позволяет переводить классический русский на его латинскую версию.  
###Пример:
>Привет, как дела? У меня всё нормально, я сегодня иду в школу.  
  
>Priv'et, kak d'ela? U m'en'a vs'o normal'no, ja s'egodn'a idu v školu.

##Использование:
Приложение представляет собой окно, в левой части которого поле для ввода текста на кириллическом русском, а справа выдаётся перевод на латинском русском.  
Проект LatinRussianLanguageClassLib.csproj можно использовать отдельно в любых других ваших решениях.  
###Список классов и их задач:
####Статичный класс Translator
Содержит только одну функцию: ```Translate(string text)``` принимающую в себя строку, после чего переводит её и возвращает результат в формате string  
####Статичный класс Alphabet
Содержит в себе методы расширения char для проверки символа на соответствие, а также словари гласных и согласных букв, которые недоступны за пределами сборки, в целях предупреждения неправильного использования.  
Метод расширения char | Применение
--- | ---
```IsCyrillic(this char letter)``` | Проверяет, является ли буква кириллической.
```IsConsonant(this char letter)``` | Проверяет, является ли буква согласной.
```IsAlwaysHardConsonant(this char letter)``` | Проверяет, проверяет, является ли согласная буква всегда твёрдой (Ц, Ш, Ж).
```IsAlwaysSoftConsonant(this char letter)``` | Проверяет, является ли согласная буква всегда мягкой (Й, Ч, Щ).
```IsVowel(this char letter)``` | Проверяет, является ли буква гласной.
```IsSoftVowel(this char letter)``` | Проверяет, раскладывается ли гласная буква на два звука (Е, Ё, Ю, Я).
```IsSign(this char letter)``` | Проверяет, является ли буква знаком (Ь, Ъ).
##Детали реализации:
####LatinRussianLanguage.csproj (WPF приложение)
При вводе текста в левое поле программа запускает перевод и выводит результат в правое поле.  
```cs
private void CurrentText_TextChanged(object sender, TextChangedEventArgs e)
{
	Translation.Text = Translator.Translate(CurrentText.Text);
}
```
####LatinRussianLanguageClassLib.csproj (Библиотека классов)
Метод ```Translate(string text)``` класса ```Translator``` выполняет всё работу по переводу текста  
Аргументы: ```string text``` - исходный текст  
Результат: переведённый текст  
```cs
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
```
Метод ```ProcessConsonant(char consonant, StringBuilder output)``` обрабатывает согласные буквы  
Аргументы:
```char consonant``` - символ согласной буквы  
```StringBuilder output``` - использующийся StringBuilder  
```cs
private static void ProcessConsonant(char consonant, StringBuilder output)
{
    output.Append(Alphabet.Consonant[consonant]);
    if (consonant == 'щ' || consonant == 'Щ') output.Append('\'');
}
```
Метод ```ProcessVowel(char vowel, char previous, StringBuilder output)``` обрабатывает гласные буквы  
Аргументы:
```char vowel``` - символ гласной буквы  
```char previous``` - символ предыдущей буквы  
```StringBuilder output``` - использующийся StringBuilder  
```cs
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
```
Метод ```ProcessSign(char sign, char previous, StringBuilder output)``` обрабатывает знаки  
Аргументы:
```char signы``` - символ знака  
```char previous``` - символ предыдущей буквы  
```StringBuilder output``` - использующийся StringBuilder  
```cs
private static void ProcessSign(char sign, char previous, StringBuilder output)
{
    if (previous.IsSign()) return;

    if (sign == 'ь')
    {
        if (!sign.IsAlwaysHardConsonant() && !previous.IsAlwaysSoftConsonant()) output.Append('\'');
    }
}
```

##Таблица со всеми буквами алфавита:
Кириллический | Латинский
--- | ---
А | A
Б | B
В | V
Г | G
Д | D
Е | Je/'e
Ё | Jo/'o
Ж | Ž
З | Z
И | I
Й | J
К | K
Л | L
М | M
Н | N
О | O
П | P
Р | R
С | S
Т | T
У | U
Ф | F
Х | H
Ц | C
Ч | Č
Ш | Š
Щ | Š'
Ъ | 
Ы | Y
Ь | '
Э | E 
Ю | Ju/'u
Я | Ja/'a
  
>Данная программа является скорее экспериментом, нежели серьёзной разработкой. В ней могут быть недоработки и ошибки.  
