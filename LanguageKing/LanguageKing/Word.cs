using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing
{
    class Word
    {
        //E, F, G, H, I
        public List<string> element = new List<string>();



        public Word(string v1, string v2, string v3, string v4, string v5)
        {

            element.Add(v1);
            element.Add(v2);
            element.Add(v3);
            element.Add(v4);
            element.Add(v5);

        }

        //Visszaadja a szót az összes nyelven
        //TODO: a hívó függvény választja majd ki a main/secondLanguage alapján a megfelelő nyelvet
        public String getWord(int lang)
        {
            return element[lang];
        }
        public void setWord(int i, string s)
        {
            element[i] = s;
        }
        

    }
}
