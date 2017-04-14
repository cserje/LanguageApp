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

        private async Task learnButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LearnWords());
        }
        
             private async Task practiceButton_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PracticeWords());
        }

        private void CloseApplication(object sender, EventArgs e)
        {

        }
    }
}
