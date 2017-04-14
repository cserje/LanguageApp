using LanguageKing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageKing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracticeWords : ContentPage
    {
        private List<Word> words = new List<Word>();
        private Random rnd = new Random();
        private List<int> randoms = new List<int>(); 

        public PracticeWords()
        {
            InitWords();
            InitializeComponent();
            BindingContext = new PracticeWordsViewModel();
            questionLabel.SetBinding(Label.TextProperty, "Text");
            button1.SetBinding(Label.TextProperty, "Text");
            button2.SetBinding(Label.TextProperty, "Text");
            button3.SetBinding(Label.TextProperty, "Text");
            button4.SetBinding(Label.TextProperty, "Text");
            GetWord();
        }

        private void GetWord()
        {
            int questionNumber = rnd.Next(words.Count);
            randoms.Add(questionNumber);

            int i = 0;
            int correctAns = rnd.Next(4);
            while (i < 3)
            {
                if (i == correctAns)
                {
                    randoms.Add(questionNumber);
                    i++;
                } else
                {
                    int answer = rnd.Next(words.Count);
                    if (!randoms.Contains(answer))
                    {
                        randoms.Add(answer);
                        i++;
                    }
                }                
            }
            
            questionLabel.BindingContext = new { Text = words[questionNumber].getWord(ChooseLanguagePage.SecondLanguage) };
            button1.BindingContext = new { Text = words[randoms[1]].getWord(ChooseLanguagePage.FirstLanguage) };
            button2.BindingContext = new { Text = words[randoms[2]].getWord(ChooseLanguagePage.FirstLanguage) };
            button3.BindingContext = new { Text = words[randoms[3]].getWord(ChooseLanguagePage.FirstLanguage) };
            button4.BindingContext = new { Text = words[randoms[4]].getWord(ChooseLanguagePage.FirstLanguage) };
        }

        private void InitWords()
        {
            //sorrend: angol, francia, német, magyar, olasz

            words.Add(new Word("one", "h un, une", "ein", "egy", "uno"));
            words.Add(new Word("two", "deux", "zwei", "kettő", "duo"));
            words.Add(new Word("three", "h trois", "drei", "három", "tre"));
            words.Add(new Word("four", "h quatre", "vier", "négy", "quattro"));
            words.Add(new Word("five", "h cinq", "fünf", "öt", "cinque"));

        }
    }
}
