using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LanguageKing
{

    public class Player
    {
        private int points = 0;
        private int correctPairs = 0;
        private int incorrectPairs = 0;
        private int correctAnswers = 0;
        private int incorrectAnswers = 0;
        private string name;

        public int CorrectPairs
        {
            get { return correctPairs; }
            set
            {
                correctPairs = value;
            }

        }
        public int IncorrectPairs
        {
            get { return incorrectPairs; }
            set
            {
                incorrectPairs = value;
            }

        }
        public Player(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public int Points
        {
            get { return points; }
            set { points=value; }
        }
         public int CorrectAnswers { get { return correctAnswers; } set { correctAnswers= value; } }
        public int IncorrectAnswers { get { return incorrectAnswers; } set { incorrectAnswers = value; } }
    }
}
