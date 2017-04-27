
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
        private WordList wordList = new WordList();

        public LearnWords()
        {
            wordList.InitWords();
            InitializeComponent();
            BindingContext = new LearnWordsViewModel();

            questionLabel.SetBinding(Label.TextProperty, "QuestionText");
            answerLabel.SetBinding(Label.TextProperty, "AnswerText");

            DependencyService.Get<ITextToSpeech>().SetLocale(ChooseLanguagePage.SecondLanguage);

            GetWords();
        }

        public void NextButtonClicked(object sender, EventArgs e)
        {
            if (count < wordList.GetSize() - 1)
            {
                count++;
            }
            else
            {
                //DisplayAlert("No more words!", "Check back later to learn more!", "Back");
                count = 0;
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
                count = wordList.GetSize() - 1;
            }
            GetWords();
        }

        public void ListenButtonClicked(object sender, EventArgs e)
        {
            String text = answerLabel.Text;
            DependencyService.Get<ITextToSpeech>().Speak(text, ChooseLanguagePage.SecondLanguage);
        }

        private void GetWords()
        {
            questionLabel.BindingContext = new { QuestionText = wordList.GetWord(count, ChooseLanguagePage.FirstLanguage) };
            answerLabel.BindingContext = new { AnswerText = wordList.GetWord(count, ChooseLanguagePage.SecondLanguage) };

            //questionLabel.BindingContext = new { QuestionText = words[count].getWord(ChooseLanguagePage.FirstLanguage) };
            //answerLabel.BindingContext = new { AnswerText = words[count].getWord(ChooseLanguagePage.SecondLanguage) };
        }

    }


}
