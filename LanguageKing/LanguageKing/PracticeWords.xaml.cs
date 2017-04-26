using LanguageKing.ViewModels;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
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
        private int decrementPointsValue = -10;
        private int currentPoints = 0;
        private int iteration = 0;
        private int limit = 5;
        Player player;

        public PracticeWords(Player player)
        {
            this.player = player;
            InitWords();
            InitializeComponent();
            BindingContext = new PracticeWordsViewModel();
            pointLabel.SetBinding(Label.TextProperty, "PointLabelText");
            countLabel.SetBinding(Label.TextProperty, "GoodPerBadLabelText");
            questionLabel.SetBinding(Label.TextProperty, "QuestionLabelText");
            button1.SetBinding(Button.TextProperty, "FirstButtonText");
            button2.SetBinding(Button.TextProperty, "SecondButtonText");
            button3.SetBinding(Button.TextProperty, "ThirdButtonText");
            button4.SetBinding(Button.TextProperty, "FourthButtonText");
            pointLabel.BindingContext = new { PointLabelText = currentPoints };
            countLabel.BindingContext = new { GoodPerBadLabelText = (iteration + 1).ToString() + "/" + limit.ToString() };
            nextButton.IsEnabled = false;
            GetWord();
        }

        private void GetWord()
        {
            iteration++;

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
                    }
                    else
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
            words.Add(new Word("one", "un, une", "ein", "egy", "uno"));
            words.Add(new Word("two", "deux", "zwei", "kettő", "duo"));
            words.Add(new Word("three", "trois", "drei", "három", "tre"));
            words.Add(new Word("four", "quatre", "vier", "négy", "quattro"));
            words.Add(new Word("five", "cinq", "fünf", "öt", "cinque"));

        }
        private void DisableButtons()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            nextButton.IsEnabled = true;
           
        }
        private void EnableButtons()
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
        private void CorrectAnswer(Button button)
        {
            
                button.BackgroundColor = Color.LightGreen;
                currentPoints += incrementPointsValue;
                pointLabel.BindingContext = new { PointLabelText = currentPoints };
            player.CorrectAnswers++;
           


        }
        private void IncorrectAnswer(Button button)
        {
            button.BackgroundColor = Color.Red;
            currentPoints += decrementPointsValue;
            pointLabel.BindingContext = new { PointLabelText = currentPoints };
            player.IncorrectAnswers++;
           

        }
      
        private void AlertAndClose()
        {
           
            Navigation.PushAsync(new Statistics(player));
            Navigation.RemovePage(this);
        }
        private void Button1_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 0) CorrectAnswer(button1);
            else IncorrectAnswer(button1);
            DisableButtons();
        }
        private void Button2_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 1) CorrectAnswer(button2);
            else IncorrectAnswer(button2);
            DisableButtons();
        }
        private void Button3_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 2) CorrectAnswer(button3);
            else IncorrectAnswer(button3);
            DisableButtons();
        }
        private void Button4_Clicked(object sender, EventArgs e)
        {
            if (correctAnswer == 3) CorrectAnswer(button4);
            else IncorrectAnswer(button4);
            DisableButtons();
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            if (iteration >= limit)
            {
                AlertAndClose();
            }
            else
            {
                countLabel.BindingContext = new { GoodPerBadLabelText = (iteration + 1).ToString() + "/" + limit.ToString() };
                EnableButtons();
                randoms.Clear();
                GetWord();
            }
        }
    }
}
