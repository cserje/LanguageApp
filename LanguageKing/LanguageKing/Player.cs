using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LanguageKing
{
   
    public class Player
    {
        private int points=0;
        private int correctAnswers = 0;
        private int incorrectAnswers = 0;
        public int Points
        {
            get { return points; }
            set { points=value; }
        }
         public int CorrectAnswers { get { return correctAnswers; } set { correctAnswers= value; } }
        public int IncorrectAnswers { get { return incorrectAnswers; } set { incorrectAnswers = value; } }
    }
}
