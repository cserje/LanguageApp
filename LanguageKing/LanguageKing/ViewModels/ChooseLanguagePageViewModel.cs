using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing.ViewModels
{
    class ChooseLanguagePageViewModel : INotifyPropertyChanged
    {
        private string[] titles = { "Select your language!", "Choisissez votre langue!", "Wählen Sie Ihre Sprache!", "Válassza ki a nyelveket!", "Seleziona la tua lingua!" };
        private string[] nextButtonText = { "Next", "Plus", "Weiter", "Tovább", "Ulteriormente" };
        private string[] secondLanguagePlaceHolder = { "Second language", "Deuxième langue", "Zweite Sprache", "Második nyelv", "Seconda lingua" };
        private int firstLanguageSelectedIndex = 0;
        private string[,] secondLanguages =
        {
            {"English","French","German","Hungarian","Italian" }, //angol
            {"Anglais","Français","Allemand","Hongrois","Italien" }, //francia
            {"Englisch","Französisch","Deutsch","Ungarisch","Italienisch" }, //német
            {"Angol","Francia","Német","Magyar","Olasz" }, //magyar
            {"Inglese","Francese","Tedesco","Ungherese","Italiano" }, //olasz
           
        };
        public List<string> SecondLanguages
        {
            get
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < secondLanguages.GetLength(1); ++i)
                {
                    if(i!=firstLanguageSelectedIndex)
                    temp.Add(secondLanguages[firstLanguageSelectedIndex, i]);
                }

                return temp;
            }
        }
        public int FirstLanguageSelectedIndex
        {
            get { return firstLanguageSelectedIndex; }
            set
            {
                firstLanguageSelectedIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(NextText));
                OnPropertyChanged(nameof(SecondLanguagePlaceHolder));
                OnPropertyChanged(nameof(SecondLanguages));
            }
        }

        public string Title
        {
            get
            {
                return titles[firstLanguageSelectedIndex];
            }
            set
            {

            }
        }
        public string NextText
        {
            get { return nextButtonText[firstLanguageSelectedIndex]; }

        }
        public string SecondLanguagePlaceHolder
        {
            get { return secondLanguagePlaceHolder[firstLanguageSelectedIndex]; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
