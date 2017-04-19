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
            correctWordLabel.SetBinding(Label.TextProperty, "CorrectWordsCount");
            incorrectWordLabel.SetBinding(Label.TextProperty, "IncorrectWordsCount");

            percentageLabel.SetBinding(Label.TextProperty, "PercentageValue");

           correctWordLabel.BindingContext = new { CorrectWordsCount = player.CorrectAnswers };
           incorrectWordLabel.BindingContext = new { IncorrectWordsCount = player.IncorrectAnswers };

        }
    }
}
