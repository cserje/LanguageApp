using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing.ViewModels
{
   class StatisticsViewModel : INotifyPropertyChanged
    {


        private string[] correctText = { "Correct Words: ", "Mots corrects: ", "Richtige Wörter: ", "Helyes megfejtés: ", "Parole corrette: " };
        private int correctWords = 0;
        private string[] incorrectText = { "Incorrect Words: ", "Mots incorrects: ", "Falsche Wörter: ", "Helytelen megfejtés: ", "Parole errate: " };
        private int incorrectWords = 0;
        private string[] percentageText = { "Percentage: ", "Pourcentage: ", "Prozentsatz: ", "Százalék: ", "Percentuale: " };

        public string CorrectWordsText
        {
            get { return correctText[ChooseLanguagePage.FirstLanguage]; }
        }
        public int CorrectWordsCount
        {
            get { return correctWords; }
            set { correctWords = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PercentageValue));
            }
        }
        public string IncorrectWordsText
        {
            get { return incorrectText[ChooseLanguagePage.FirstLanguage]; }
        }
        public int IncorrectWordsCount
        {
            get { return incorrectWords; }
            set { incorrectWords = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PercentageValue));
            }

        }
        public string PercentageText
        {
            get { return percentageText[ChooseLanguagePage.FirstLanguage]; }
            
        }
        public double PercentageValue
        {
            get
            {
                if (correctWords == 0)
                {
                    return 0;
                }
                else if (incorrectWords == 0)
                {
                    return 100;
                }
                else
                    return ((double)correctWords / (double)incorrectWords)*100;
            }
          
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
