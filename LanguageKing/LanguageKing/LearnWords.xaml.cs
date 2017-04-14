
using LanguageKing.ViewModels;
using Plugin.TextToSpeech;
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
        private int count=0;
        private List<Word> words=new List<Word>();
       
        public LearnWords()
        {
            InitWords();
            InitializeComponent();
            BindingContext = new LearnWordsViewModel();
            questionLabel.SetBinding(Label.TextProperty, "Text");
            answerLabel.SetBinding(Label.TextProperty, "Text");
            GetWord();
        }

        private void Learn()
        {            
            InitWords();            
        }

        public void nextButtonClicked(object sender, EventArgs e)
        {
            if (count < words.Count - 1)
            {
                count++;
            }
            else
            {
                DisplayAlert("No more words!", "Check back later to learn more!", "Back");
            }
            GetWord();
        }

        public void backButtonClicked(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count--;
            }
            GetWord();
        }

        public void listenButtonClicked(object sender, EventArgs e)
        {
            String text = questionLabel.Text;
            DependencyService.Get<ITextToSpeech>().Speak(text, ChooseLanguagePage.SecondLanguage);
            //CrossTextToSpeech.Current.Speak("Orbán Viktor Magyarország királya");
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

        private void GetWord()
        {
            //Debug.WriteLine(words[count].getWord(ChooseLanguagePage.SecondLanguage));
            //Debug.WriteLine(words[count].getWord(ChooseLanguagePage.FirstLanguage));
            questionLabel.BindingContext = new { Text = words[count].getWord(ChooseLanguagePage.SecondLanguage) };
            answerLabel.BindingContext = new { Text = words[count].getWord(ChooseLanguagePage.FirstLanguage) };
        }

    }

    
}
