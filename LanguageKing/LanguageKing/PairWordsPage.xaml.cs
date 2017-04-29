using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageKing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PairWordsPage : ContentPage
    {
        private Player player;
        private WordList wordList = new WordList();
        List<Button> buttons = new List<Button>();
        Button lastPressedButton = new Button();
        List<Color> colors = new List<Color>();
        private List<int> randoms = new List<int>();
        private Random rnd = new Random();
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
            colors.Add(Color.Pink);
            colors.Add(Color.Pink);
            colors.Add(Color.Yellow);
            colors.Add(Color.Yellow);
            colorLabel.BackgroundColor = colors[0];
            CheckProperty();
            GetWord();
        }
        private void CheckProperty()
        {
            for (int i = 0; i < buttons.Count; ++i)
            {
                buttons[i].Text = "Text";
                buttons[i].BackgroundColor = Color.Default;
            }
        }
        private void GetWord()
        {
            int i = 0;
            int selectedIndex = 0;
            List<int> buttonIndexes = new List<int>();
            
            //gomb indexek 0-tól 8-ig
            while (i < 8)
            {
                selectedIndex=rnd.Next(8);
                if (!buttonIndexes.Contains(selectedIndex))
                {
                    buttonIndexes.Add(selectedIndex);
                    ++i;
                }
            }
            //for ( i = 0; i < buttonIndexes.Count; ++i)
            //    DisplayAlert("Asd", buttonIndexes[i].ToString(), "Vissza");
            i = 0;
            List<int> wordIndexes= new List<int>();

            //4 szó kiválasztása, a stringek belerakása egy tömbbe
            List<string> buttonTextArray = new List<string>();
            while (i < 4)
            {
                selectedIndex = rnd.Next(wordList.GetSize());
                if (!wordIndexes.Contains(selectedIndex))
                {
                    buttonTextArray.Add(wordList.GetWord(selectedIndex,ChooseLanguagePage.FirstLanguage));
                    buttonTextArray.Add(wordList.GetWord(selectedIndex, ChooseLanguagePage.SecondLanguage));
                    wordIndexes.Add(selectedIndex);
                    ++i;
                }
            }
          for(i=0;i<buttonIndexes.Count;++i)
            {
                buttons[buttonIndexes[i]].Text = buttonTextArray[i];
            }
          

        }

        
        private bool FirstButtonPressed(Button b)
        {
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
            if (colors.Count > 0)
            {
                colorLabel.BackgroundColor = colors[0];
            }
            else
            {
                colorLabel.BackgroundColor = Color.Default;
            }
        }

    }

}
