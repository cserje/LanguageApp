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
    public partial class MainMenuPage : ContentPage
    {


        public MainMenuPage()
        {
            InitializeComponent();
            BindingContext = new MainMenuPageViewModel();
        }

        private void  learnButton_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new LearnWords());
        }

        private void practiceButton_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new PracticeWords());
        }

        private void CloseApplication(object sender, EventArgs e)
        {

        }

    }
}
