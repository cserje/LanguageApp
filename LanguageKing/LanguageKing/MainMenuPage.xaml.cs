using LanguageKing.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageKing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public Player player = new Player("Jatekos", 0);

        public MainMenuPage()
        {
            InitializeComponent();
            BindingContext = new MainMenuPageViewModel();
        }

        private void LearnButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryChoosingPage(1, player));
        }

        private void PracticeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryChoosingPage(2, player));
        }
        private void PairWords_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryChoosingPage(3, player));
        }

        private void StatisticsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Statistics(player));
        }

        private void CloseApplication(object sender, EventArgs e)
        {

        }

    }
}
