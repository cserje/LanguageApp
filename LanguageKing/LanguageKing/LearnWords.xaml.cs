
using LanguageKing.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageKing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LearnWords : ContentPage
    {
        private int count = 0;
        private List<Word> words = new List<Word>();

        public LearnWords()
        {
            InitWords();
            InitializeComponent();
            BindingContext = new LearnWordsViewModel();

            questionLabel.SetBinding(Label.TextProperty, "QuestionText");
            answerLabel.SetBinding(Label.TextProperty, "AnswerText");

            GetWord();
        }

        private void Learn()
        {
            InitWords();
        }

        public void NextButtonClicked(object sender, EventArgs e)
        {
            if (count < words.Count - 1)
            {
                count++;
            }
            else
            {
                //DisplayAlert("No more words!", "Check back later to learn more!", "Back");
                count = 0;
            }
            GetWord();
        }

        public void BackButtonClicked(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count--;
            }
            else if (count == 0)
            {
                count = words.Count - 1;
            }
            GetWord();
        }

        public void ListenButtonClicked(object sender, EventArgs e)
        {
            String text = answerLabel.Text;
            DependencyService.Get<ITextToSpeech>().Speak(text, ChooseLanguagePage.SecondLanguage);

        }

        private void InitWords()
        {
            //sorrend: angol, francia, német, magyar, olasz

            words.Add(new Word("one", "une", "ein", "egy", "uno"));
            words.Add(new Word("two", "deux", "zwei", "kettő", "duo"));
            words.Add(new Word("three", "trois", "drei", "három", "tre"));
            words.Add(new Word("four", "quatre", "vier", "négy", "quattro"));
            words.Add(new Word("five", "cinq", "fünf", "öt", "cinque"));
            words.Add(new Word("six", "six", "sechs", "hat", "sei"));
            words.Add(new Word("seven", "sept", "sieben", "hét", "sette"));
            words.Add(new Word("eight", "huit", "acht", "nyolc", "otto"));
            words.Add(new Word("nine", "neuf", "neun", "kilenc", "nove"));
            words.Add(new Word("ten", "dix", "zehn", "tíz", "dieci"));
        }

        private void GetWord()
        {

            questionLabel.BindingContext = new { QuestionText = words[count].getWord(ChooseLanguagePage.FirstLanguage) };
            answerLabel.BindingContext = new { AnswerText = words[count].getWord(ChooseLanguagePage.SecondLanguage) };
        }

    }


}
