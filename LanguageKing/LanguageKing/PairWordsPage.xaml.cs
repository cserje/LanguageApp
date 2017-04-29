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
    public partial class PairWordsPage : ContentPage
    {
        private Player player;
        private WordList wordList = new WordList();
        List<Button> buttons= new List<Button>();
        Button lastPressedButton = new Button();
        List<Color> colors = new List<Color>();
        public PairWordsPage(Player player)
        {
            this.player = player;
            InitializeComponent();
            wordList.InitWords();
            pairWordsLabel.Text = "Hello World!";
            buttons.Add(firstFirstButton);
            buttons.Add(secondFirstButton);
            buttons.Add(thirdFirstButton);
            buttons.Add(fourthFirstButton);
            buttons.Add(firstSecondButton);
            buttons.Add(secondSecondButton);
            buttons.Add(thirdSecondButton);            
            buttons.Add(fourthSecondButton);
            colors.Add(Color.LightBlue);
            colors.Add(Color.LightBlue);
            colors.Add(Color.LightGreen);
            colors.Add(Color.LightGreen);
            colors.Add(Color.LightPink);
            colors.Add(Color.LightPink);
            colors.Add(Color.LightYellow);
            colors.Add(Color.LightYellow);
            CheckProperty();
            //BindingContext
        }
        private void CheckProperty()
        {
            for(int i=0;i<buttons.Count;++i)
            {
                buttons[i].Text = "Text";
                buttons[i].BackgroundColor = Color.Default;
            }
           

        }
        private bool FirstButtonPressed(Button b) {
            for (int i = 0; i < buttons.Count / 2; ++i)
                if (buttons[i].Id == b.Id)
                    return true;
            return false;
                }
        
        private void Button_Clicked(object sender, EventArgs e)
        {

            Button button = sender as Button;
            //Arra kell, hogy vissza lehessen vonni a színeket, ha megnyomom kétszer ugyanazt a gombot, akkor váltson majd vissza a színe.
            //Majd implementálni kell egy olyan listát, tömböt, ahol az első helyre be lehet szúrni elemet
            //A 8 gomb akármelyikén lehet akármelyik nyelv


                if (lastPressedButton != null && lastPressedButton.Id == button.Id || button.BackgroundColor != Color.Default)
                {

                    lastPressedButton = null;
                    colors.Insert(0, button.BackgroundColor);
                    button.BackgroundColor = Color.Default;
                }
                else
                {
                    button.BackgroundColor = colors[0];
                    colors.RemoveAt(0);
                    lastPressedButton = button;
                }

            }

            
           
        }


    }
