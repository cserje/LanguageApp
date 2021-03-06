﻿using LanguageKing.ViewModels;
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
        private WordList wordList = WordList.Instance;
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
            //wordList.InitWords();
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

            int questionNumber = rnd.Next(wordList.GetSize());

            randoms.Add(questionNumber);

            int i = 0;
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
                    int answer = rnd.Next(wordList.GetSize());
                    if (!randoms.Contains(answer))
                    {
                        randoms.Add(answer);
                        i++;
                    }
                }
            }
            questionLabel.BindingContext = new { QuestionLabelText = wordList.GetWord(questionNumber, ChooseLanguagePage.SecondLanguage) };
            button1.BindingContext = new { FirstButtonText = wordList.GetWord(randoms[1], ChooseLanguagePage.FirstLanguage) };
            button2.BindingContext = new { SecondButtonText = wordList.GetWord(randoms[2], ChooseLanguagePage.FirstLanguage) };
            button3.BindingContext = new { ThirdButtonText = wordList.GetWord(randoms[3], ChooseLanguagePage.FirstLanguage) };
            button4.BindingContext = new { FourthButtonText = wordList.GetWord(randoms[4], ChooseLanguagePage.FirstLanguage) };


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
            player.Points += incrementPointsValue;
            player.CorrectAnswers++;
        }

        private void IncorrectAnswer(Button button)
        {
            button.BackgroundColor = Color.Red;
            currentPoints += decrementPointsValue;
            pointLabel.BindingContext = new { PointLabelText = currentPoints };
            player.Points += decrementPointsValue;
            player.IncorrectAnswers++;
        }

        private void AlertAndClose()
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new Statistics(player));
            //Navigation.RemovePage(this);
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
