using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing.ViewModels
{
    class MainMenuPageViewModel : INotifyPropertyChanged
    {
       
        public string[] learnButtonText = { "Learn Words", "Apprendre des mots", "Wörter lernen", "Szavak tanulása", "Imparare le parolee" };
        public string[] practiceButtonText = { "Practice", "Praxis", "Pratique", "Gyakorlás", "Pratica" };
        public string[] statisticsButtonText = { "Statistics", "Statistiques", "Statistiken", "Statisztikák", "Statistica" };
        public string[] quitButtonText = { "Quit", "Praxis", "Egress", "Kilépés", "Uscita" };
        public string LearnText
        {
            get { return learnButtonText[ChooseLanguagePage.FirstLanguage]; }
        }
       public string PracticeText
        {
            get { return practiceButtonText[ChooseLanguagePage.FirstLanguage]; }
        }
        public string StatisticsText
        {
            get { return statisticsButtonText[ChooseLanguagePage.FirstLanguage]; }
        }
        public string QuitText
        {
            get { return quitButtonText[ChooseLanguagePage.FirstLanguage]; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
