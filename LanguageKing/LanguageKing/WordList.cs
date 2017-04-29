using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing
{
    class WordList
    {
        private List<Word> words = new List<Word>();
        private string[] nextButtonText = { "Next", "Plus", "Weiter", "Tovább", "Ulteriormente" };
        private string[] checkButtonText = { "Check", "Inspection", "Inspektion", "Ellenőrzés", "Ispezione" };
        private string[] pairTheWordsText = { "Match the words!", "Associez les mots!", "Pair die Worte!", "Párosítsd a szavakat!", "Accoppi le parole!" };
        private string[] incorrectSolutionsText = { "To correct the incorrect solutions", "Pour corriger les solutions incorrectes", "Um die falschen Lösungen zu korrigieren","A helytelen megoldás(ok) kijavítása", "Per correggere le soluzioni non corrette" };
        private string[] backButtonText = { "Back", "Dos", "Zurück", "Vissza", "Indietro", };
        private string[] perfectText = { "Perfect", "Parfait", "Perfekt", "Tökéletes", "Perfetto" };
        private string[] correctSolutionText = { "Perfect solution", "Solution parfaite", "Perfekte Lösung", "Hibátlan megoldás", "Soluzione perfetta" };
        private string[] statisticsCorrectText = { "Correct Words: ", "Mots corrects: ", "Richtige Wörter: ", "Helyes megfejtés: ", "Parole corrette: " };
        private string[] statisticsIncorrectText = { "Incorrect Words: ", "Mots incorrects: ", "Falsche Wörter: ", "Helytelen megfejtés: ", "Parole errate: " };
        private string[] statisticsCorrectMatchText = { "Correct match:", "Appariement correct:", "Korrekte Paarung:", "Helyes párosítás:", "Corretto abbinamento:" };
        private string[] statisticsIncorrectMatchText = { "Incorrect match:", "Correspondance incorrecte:", "Falsche Paarung:", "Rossz párosítás:", "Corrispondenza errata:" };
        private string[] pointLabelText = { "Points: ", "Points: ", "Punkte: ", "Pontok: ", "Punti: " };

        public string GetPointLabelText(int lang)
        {
            return pointLabelText[ChooseLanguagePage.FirstLanguage];
        }
        public string GetStatisticsCorrectMatchText(int lang)
        {
            return statisticsCorrectMatchText[lang];
        }
        public string GetStatisticsIncorrectMatchText(int lang)
        {
            return statisticsIncorrectMatchText[lang];
        }
        public string GetStatisticsCorrectText(int lang)
        {
            return statisticsCorrectText[lang];
        }
        public string GetStatisticsIncorrectText(int lang)
        {
            return statisticsIncorrectText[lang];
        }
        public string GetPerfectText(int lang)
        {
            return perfectText[lang];
        }
        public string GetCorrectSolutionText(int lang)
        {
            return correctSolutionText[lang];
        }
        public string GetIncorrectSolutionsText(int lang)
        {
            return incorrectSolutionsText[lang];
        }
        public string GetBackButtonText(int lang)
        {
            return backButtonText[lang];
        }
        public string GetpairTheWordsText(int lang)
        {
            return pairTheWordsText[lang];
        }
        public string GetCheckText(int lang)
        {
            return checkButtonText[lang];
        }

        public string GetNextText(int lang)
        {
            return nextButtonText[lang];
        }
        public string GetWord(int count, int lang)
        {
            return words[count].getWord(lang);
        }

        public void AddWord(Word newWord)
        {
            words.Add(newWord);
        }

        public void InitWords()
        {
            //sorrend: angol, francia, német, magyar, olasz

            words.Add(new Word("one", "un", "ein", "egy", "uno"));
            words.Add(new Word("two", "deux", "zwei", "kettő", "duo"));
            words.Add(new Word("three", "trois", "drei", "három", "tre"));
            words.Add(new Word("four", "quatre", "vier", "négy", "quattro"));
            words.Add(new Word("five", "cinq", "fünf", "öt", "cinque"));
        }
        public int getIndexFromWord(string word)
        {
            for (int i = 0; i < words.Count; ++i)
            {
                if (words[i].element[ChooseLanguagePage.FirstLanguage].Equals(word) || words[i].element[ChooseLanguagePage.SecondLanguage].Equals(word))
                    return i;
            }
            throw new Exception("Nincs ilyen szó a szavak között!");
        }

        public int GetSize()
        {
            return words.Count;
        }
    }
}
