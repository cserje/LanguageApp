﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing.ViewModels
{
    class PracticeWordsViewModel : INotifyPropertyChanged
    {
        private string[] nextButtonText = { "Next", "Plus", "Weiter", "Tovább", "Ulteriormente" };
        private string[] pointLabelText = { "Points: ", "Points: ", "Punkte: ", "Pontok: ", "Punti: " };
        private string questionLabelText;
        private string firstButtonText;
        private string secondButtonText;
        private string thirdButtonText;
        private string fourthButtonText;
        private int points = 0;
        private string counter = "";
        public string GoodPerBadLabelText {  set { counter = value; } }
        public string PointLabelText
        {
            get { return pointLabelText[ChooseLanguagePage.FirstLanguage]; }
        }
        public int PointsText
        {
            get { return points; }
            set
            {
                points = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(GoodPerBadLabelText));
            }
        }
        public string QuestionLabelText
        {
            get
            {
                return questionLabelText;
            }
            set
            {
                questionLabelText = value;
                OnPropertyChanged();
            }
        }

        public string FirstButtonText
        {
            get
            {
                return firstButtonText;
            }
            set
            {
                firstButtonText = value;
                OnPropertyChanged();
            }
        }

        public string SecondButtonText
        {
            get
            {
                return secondButtonText;
            }
            set
            {
                secondButtonText = value;
                OnPropertyChanged();
            }
        }

        public string ThirdButtonText
        {
            get
            {
                return thirdButtonText;
            }
            set
            {
                thirdButtonText = value;
                OnPropertyChanged();
            }
        }

        public string FourthButtonText
        {
            get
            {
                return fourthButtonText;
            }
            set
            {
                fourthButtonText = value;
                OnPropertyChanged();
            }
        }
        public string NextButtonText
        {
            get { return nextButtonText[ChooseLanguagePage.FirstLanguage]; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
