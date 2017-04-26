using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing.ViewModels
{
    class PracticeWordsViewModel
    {
        private string[] nextButtonText = { "Next", "Plus", "Weiter", "Tovább", "Ulteriormente" };
        private string[] pointLabelText = { "Points: ", "Points: ", "Punkte: ", "Pontok: ", "Punti: " };
        private string questionLabelText;

  
        public string PointLabelText
        {
            get { return pointLabelText[ChooseLanguagePage.FirstLanguage]; }
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
               
            }
        }

       
        public string NextButtonText
        {
            get { return nextButtonText[ChooseLanguagePage.FirstLanguage]; }
        }

       
    }
}
