using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing.ViewModels
{
   class StatisticsViewModel 
    {


        private string[] correctText = { "Correct Words: ", "Mots corrects: ", "Richtige Wörter: ", "Helyes megfejtés: ", "Parole corrette: " };
        private int correctWords = 0;
        private string[] incorrectText = { "Incorrect Words: ", "Mots incorrects: ", "Falsche Wörter: ", "Helytelen megfejtés: ", "Parole errate: " };
        private int incorrectWords = 0;
       

        public string CorrectWordsText
        {
            get { return correctText[ChooseLanguagePage.FirstLanguage]; }
        }
        public int CorrectWordsCount
        {
            get { return correctWords; }
            set { correctWords = value;
               
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
               
            }

        }



    }
}
