using LanguageKing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageKing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistics : ContentPage
    {

        public Statistics(Player player)
        {
            InitializeComponent();
            BindingContext = new StatisticsViewModel();
            WordList words = WordList.Instance;
            //words.InitWords();
            pointLabel.Text = words.GetPointLabelText(ChooseLanguagePage.FirstLanguage)+player.Points.ToString();
            correctTextLabel.Text = words.GetStatisticsCorrectText(ChooseLanguagePage.FirstLanguage);
            inCorrectTextLabel.Text = words.GetStatisticsIncorrectText(ChooseLanguagePage.FirstLanguage);
            correctPairsTextLabel.Text = words.GetStatisticsCorrectMatchText(ChooseLanguagePage.FirstLanguage);
            incorrectPairsTextLabel.Text = words.GetStatisticsIncorrectMatchText(ChooseLanguagePage.FirstLanguage);
     
           correctWordLabel.Text= player.CorrectAnswers.ToString();
           incorrectWordLabel.Text = player.IncorrectAnswers.ToString();
            correctPairsCountLabel.Text = player.CorrectPairs.ToString();
            incorrectPairsCountLabel.Text = player.IncorrectPairs.ToString();

        }
    }
}
