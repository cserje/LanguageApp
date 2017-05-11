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
        private WordList wordList = WordList.Instance;
        private string[] locales;

        public LearnWords()
        {
            locales = new string[wordList.GetLocaleCount()];
            locales = wordList.GetLocales();
            InitializeComponent();
            BindingContext = new LearnWordsViewModel();
            GetWords();
        }

        public void NextButtonClicked(object sender, EventArgs e)
        {
            if (count + 2 < wordList.GetSize() - 1)
            {
                count++;
            }
            else
            {
                if(count == wordList.GetSize() - 3)
                {
                    count = 0;
                }
                else
                {
                    count = wordList.GetSize() - 3;
                }
            }
            GetWords();
        }

        public void BackButtonClicked(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count--;
            }
            else if (count == 0)
            {
                count = wordList.GetSize() - 3;
            }
            GetWords();
        }

        public void ListenButtonClicked1(object sender, EventArgs e)
        {

            String text = answerLabel1.Text;
            //DependencyService.Get<ITextToSpeech>().Speak(text, ChooseLanguagePage.SecondLanguage);
            DependencyService.Get<ITextToSpeech>().Speak(text, locales[ChooseLanguagePage.SecondLanguage]);
        }
        public void ListenButtonClicked2(object sender, EventArgs e)
        {

            String text = answerLabel2.Text;
            //DependencyService.Get<ITextToSpeech>().Speak(text, ChooseLanguagePage.SecondLanguage);
            DependencyService.Get<ITextToSpeech>().Speak(text, locales[ChooseLanguagePage.SecondLanguage]);
        }
        public void ListenButtonClicked3(object sender, EventArgs e)
        {

            String text = answerLabel3.Text;
            //DependencyService.Get<ITextToSpeech>().Speak(text, ChooseLanguagePage.SecondLanguage);
            DependencyService.Get<ITextToSpeech>().Speak(text, locales[ChooseLanguagePage.SecondLanguage]);
        }

        private void GetWords()
        {
            questionLabel1.Text = wordList.GetWord(count, ChooseLanguagePage.FirstLanguage);
            answerLabel1.Text = wordList.GetWord(count, ChooseLanguagePage.SecondLanguage);
            questionLabel2.Text = wordList.GetWord(count + 1, ChooseLanguagePage.FirstLanguage);
            answerLabel2.Text = wordList.GetWord(count + 1, ChooseLanguagePage.SecondLanguage);
            questionLabel3.Text = wordList.GetWord(count + 2, ChooseLanguagePage.FirstLanguage);
            answerLabel3.Text = wordList.GetWord(count + 2, ChooseLanguagePage.SecondLanguage);
        }

    }


}
