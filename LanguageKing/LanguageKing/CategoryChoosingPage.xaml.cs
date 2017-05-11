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
    public partial class CategoryChoosingPage : ContentPage
    {
        private WordList wordList = WordList.Instance;
        int selected_category = -1;
        string[,] categories;
        int nextPage = -1;
        public Player player;

        public CategoryChoosingPage(int nextPage, Player player)
        {
            this.player = player;
            this.nextPage = nextPage;
            InitializeComponent();
            //tesztadatok, amik bekerülnek a pickerbe
            //A megfelelő nyevhez tartozó kategória beállítása a pickerhez, illetve a gomhoz a megfelelő nyeven beállítva a következő szöveg
            categoryPicker.Title = wordList.GetCategoryPlaceHolder(ChooseLanguagePage.FirstLanguage);
            categories = wordList.GetCategories();
            categoryPicker.ItemsSource = Categories;
            nextButton.Text = wordList.GetNextText(ChooseLanguagePage.FirstLanguage);
        }

        public List<string> Categories
        {
            get
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < categories.GetLength(0); i++)
                {
                    temp.Add(categories[i, ChooseLanguagePage.FirstLanguage]);
                }

                return temp;
            }
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            if (selected_category != -1)
            {
                switch (nextPage)
                {
                    case 1:
                        wordList.LoadWords(selected_category + 1);
                        Navigation.PushAsync(new LearnWords());
                        break;
                    case 2:
                        wordList.LoadWords(selected_category + 1);
                        Navigation.PushAsync(new PracticeWords(player));
                        break;
                    case 3:
                        wordList.LoadWords(selected_category + 1);
                        Navigation.PushAsync(new PairWordsPage(player));
                        break;
                    default:
                        DisplayAlert("Error", "Transferring you to the next page failed!", "Back");
                        break;
                }
            }
        }
        private void OnCategoryChanged(object sender, EventArgs e)
        {
            selected_category = categoryPicker.SelectedIndex;
        }
    }
}
