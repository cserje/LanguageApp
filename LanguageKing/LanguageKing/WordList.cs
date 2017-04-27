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

            words.Add(new Word("one", "un, une", "ein", "egy", "uno"));
            words.Add(new Word("two", "deux", "zwei", "kettő", "duo"));
            words.Add(new Word("three", "trois", "drei", "három", "tre"));
            words.Add(new Word("four", "quatre", "vier", "négy", "quattro"));
            words.Add(new Word("five", "cinq", "fünf", "öt", "cinque"));
        }

        public int GetSize()
        {
            return words.Count;
        }
    }
}
