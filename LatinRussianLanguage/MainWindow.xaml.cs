using System.Windows;
using System.Windows.Controls;
using LatinRussianLanguageClassLib;

namespace LatinRussianLanguage;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CurrentText_TextChanged(object sender, TextChangedEventArgs e)
    {
        Translation.Text = Translator.Translate(CurrentText.Text);
    }
}