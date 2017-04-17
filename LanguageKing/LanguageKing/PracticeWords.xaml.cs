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
        private int correctAnswer = -1;
        private int incrementPointsValue = 10;
        private int points = 0;

        public PracticeWords()
        {
            InitWords();
            InitializeComponent();
            BindingContext = new PracticeWordsViewModel();
            pointLabel.SetBinding(Label.TextProperty, "PointLabelText");
            questionLabel.SetBinding(Label.TextProperty, "QuestionLabelText");
            button1.SetBinding(Button.TextProperty, "FirstButtonText");
            button2.SetBinding(Button.TextProperty, "SecondButtonText");
            button3.SetBinding(Button.TextProperty, "ThirdButtonText");
            button4.SetBinding(Button.TextProperty, "FourthButtonText");
            nextButton.IsEnabled = false;
            GetWord();
        }

        private void GetWord()
        {
            //létrehozunk egy intet, az alap listában annyiadik szó lesz a kérdés
            int questionNumber = rnd.Next(words.Count);
            //a random listába belepakoljuk ezt a számot
            randoms.Add(questionNumber);

            int i = 0;
            //kiválasztjuk, hogy a jó válasznak mi legyen az indexe
            int correctAns = rnd.Next(4);
            correctAnswer = correctAns;
            while (i < 4)
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
            
            questionLabel.BindingContext = new { QuestionLabelText = words[questionNumber].getWord(ChooseLanguagePage.SecondLanguage) };
            button1.BindingContext = new { FirstButtonText = words[randoms[1]].getWord(ChooseLanguagePage.FirstLanguage) };
            button2.BindingContext = new { SecondButtonText = words[randoms[2]].getWord(ChooseLanguagePage.FirstLanguage) };
            button3.BindingContext = new { ThirdButtonText = words[randoms[3]].getWord(ChooseLanguagePage.FirstLanguage) };
            button4.BindingContext = new { FourthButtonText = words[randoms[4]].getWord(ChooseLanguagePage.FirstLanguage) };
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
        private void disableButtons()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            nextButton.IsEnabled = true;
        }
        private void enableButtons()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            nextButton.IsEnabled = false;
            button1.BackgroundColor = Color.LightGray;
            button2.BackgroundColor = Color.LightGray;
            button3.BackgroundColor = Color.LightGray;
            button4.BackgroundColor = Color.LightGray;
        }
        private void button1_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 0)
            {
               
                button1.BackgroundColor = Color.LightGreen;
                points += incrementPointsValue;
                pointLabel.BindingContext = new { PointLabelText = points};
            }
            else
            {
                
                button1.BackgroundColor = Color.Red;
            }
            disableButtons();
        }
        private void button2_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 1)
            {
                
                button2.BackgroundColor = Color.LightGreen;
                points += incrementPointsValue;
                pointLabel.BindingContext = new { PointLabelText = points };

            }
            else
            {
               
                button2.BackgroundColor = Color.Red;

            }
            disableButtons();
        }
        private void button3_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 2)
            {
                
                button3.BackgroundColor = Color.LightGreen;
                points += incrementPointsValue;
                pointLabel.BindingContext = new { PointLabelText = points };
            }
            else
            {
              
                button3.BackgroundColor = Color.Red;
            }
            disableButtons();
        }
        private void button4_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 3)
            {
                
                button4.BackgroundColor = Color.LightGreen;
                points += incrementPointsValue;
                pointLabel.BindingContext = new { PointLabelText = points };
            }
            else
            {
                
                button4.BackgroundColor = Color.Red;
            }
            disableButtons();
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            enableButtons();
            randoms.Clear();
            GetWord();
        }
    }
}
