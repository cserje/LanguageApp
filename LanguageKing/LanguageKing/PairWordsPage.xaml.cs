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
        private WordList wordList = WordList.Instance;
        List<Button> buttons = new List<Button>();
        Button lastPressedButton = new Button();
        List<Color> colors = new List<Color>();
        private List<int> randoms = new List<int>();
        private int currentPoints=0;
        private Random rnd = new Random();
        private int iteration = 1;
        private int limit = 2;
        public PairWordsPage(Player player)
        {
            this.player = player;
            InitializeComponent();
            //wordList.InitWords();
            pairWordsLabel.Text = wordList.GetpairTheWordsText(ChooseLanguagePage.FirstLanguage);
            buttons.Add(firstFirstButton);
            buttons.Add(secondFirstButton);
            buttons.Add(thirdFirstButton);
            buttons.Add(fourthFirstButton);
            buttons.Add(firstSecondButton);
            buttons.Add(secondSecondButton);
            buttons.Add(thirdSecondButton);
            buttons.Add(fourthSecondButton);
            ResetColors();
            colorLabel.BackgroundColor = colors[0];
            pointLabel.Text = wordList.GetPointLabelText(ChooseLanguagePage.FirstLanguage)+currentPoints.ToString();
            checkButton.Text = wordList.GetCheckText(ChooseLanguagePage.FirstLanguage);
            nextButton.Text = wordList.GetNextText(ChooseLanguagePage.FirstLanguage);
            countLabel.Text = iteration.ToString() + "/" + limit.ToString();
            checkButton.IsEnabled = false;
            nextButton.IsEnabled = false;
           
            GetWord();
        }
       
        private void GetWord()
        {
            int i = 0;
            int selectedIndex = 0;
            List<int> buttonIndexes = new List<int>();

            //gomb indexek 0-tól 7-ig
            while (i < 8)
            {
                selectedIndex = rnd.Next(8);
                if (!buttonIndexes.Contains(selectedIndex))
                {
                    buttonIndexes.Add(selectedIndex);
                    ++i;
                }
            }

            i = 0;
            List<int> wordIndexes = new List<int>();

            //4 szó kiválasztása, a stringek belerakása egy tömbbe
            List<string> buttonTextArray = new List<string>();
            while (i < 4)
            {
                selectedIndex = rnd.Next(wordList.GetSize());
                if (!wordIndexes.Contains(selectedIndex))
                {
                    buttonTextArray.Add(wordList.GetWord(selectedIndex, ChooseLanguagePage.FirstLanguage));
                    buttonTextArray.Add(wordList.GetWord(selectedIndex, ChooseLanguagePage.SecondLanguage));
                    wordIndexes.Add(selectedIndex);
                    ++i;
                }
            }
            for (i = 0; i < buttonIndexes.Count; ++i)
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
        private void ResetColors()
        {
            colors.Add(Color.LightBlue);
            colors.Add(Color.LightBlue);
            colors.Add(Color.LightGreen);
            colors.Add(Color.LightGreen);
            colors.Add(Color.LightPink);
            colors.Add(Color.LightPink);
            colors.Add(Color.Gold);
            colors.Add(Color.Gold);
        }
        private void Check_Clicked()
        {

            List<Color> tempColors = new List<Color>();
            tempColors.Add(Color.LightBlue);
            tempColors.Add(Color.LightBlue);
            tempColors.Add(Color.LightGreen);
            tempColors.Add(Color.LightGreen);
            tempColors.Add(Color.LightPink);
            tempColors.Add(Color.LightPink);
            tempColors.Add(Color.Gold);
            tempColors.Add(Color.Gold);
            List<string> pairs = new List<string>();
            int i = 0;

            while (i < 8)
            {
                for (int j = 0; j < buttons.Count; ++j)
                {
                    if (i < 8)
                    {
                        if (buttons[j].BackgroundColor.Equals(tempColors[i]))
                        {

                            pairs.Add(buttons[j].Text);
                            ++i;
                        }
                    }
                }
            }
            List<int> incorrectWordIndexes = new List<int>();
            for (i = 0; i < pairs.Count - 1; i += 2)
            {
                if (wordList.getIndexFromWord(pairs[i]) != wordList.getIndexFromWord(pairs[i + 1]))
                {
                    if (!incorrectWordIndexes.Contains(wordList.getIndexFromWord(pairs[i])))
                        incorrectWordIndexes.Add(wordList.getIndexFromWord(pairs[i]));
                    if (!incorrectWordIndexes.Contains(wordList.getIndexFromWord(pairs[i + 1])))
                        incorrectWordIndexes.Add(wordList.getIndexFromWord(pairs[i + 1]));

                }
            }
            string text = "";
            for (i = 0; i < incorrectWordIndexes.Count; ++i)
            {
                text += wordList.GetWord(incorrectWordIndexes[i], ChooseLanguagePage.FirstLanguage) + " - " + wordList.GetWord(incorrectWordIndexes[i], ChooseLanguagePage.SecondLanguage) + "\n";
            }
            player.CorrectPairs += (4 - incorrectWordIndexes.Count);
            player.IncorrectPairs += incorrectWordIndexes.Count;
            player.Points += ((4 - incorrectWordIndexes.Count) - incorrectWordIndexes.Count) * 10;
            currentPoints += ((4 - incorrectWordIndexes.Count) - incorrectWordIndexes.Count) * 10;
            pointLabel.Text = currentPoints.ToString();
            if (incorrectWordIndexes.Count > 0)
            {
                DisplayAlert(wordList.GetIncorrectSolutionsText(ChooseLanguagePage.FirstLanguage), text, wordList.GetNextText(ChooseLanguagePage.FirstLanguage));
            }
            else
            {
                DisplayAlert(wordList.GetPerfectText(ChooseLanguagePage.FirstLanguage), wordList.GetCorrectSolutionText(ChooseLanguagePage.FirstLanguage) + "!", wordList.GetNextText(ChooseLanguagePage.FirstLanguage));
            }
            DisableAll();

        }
        void DisableAll()
        {
            for (int i = 0; i < buttons.Count; ++i)
            {
                buttons[i].IsEnabled = false;
            }
            checkButton.IsEnabled = false;
            nextButton.IsEnabled = true;
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
                checkButton.IsEnabled = false;
                colorLabel.BackgroundColor = colors[0];

            }
            else
            {
                checkButton.IsEnabled = true;
                colorLabel.BackgroundColor = Color.Default;

            }


        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            iteration++;
            if (iteration<=limit){
                GetWord();
                for (int i = 0; i < buttons.Count; ++i)
                {
                    buttons[i].IsEnabled = true;
                    buttons[i].BackgroundColor = Color.Default;
                }
                nextButton.IsEnabled = false;
                ResetColors();
            }
            else
            {
                Navigation.PopAsync();
                Navigation.PushAsync(new Statistics(player));
                //Navigation.RemovePage(this);
            }
        }
    }

}
