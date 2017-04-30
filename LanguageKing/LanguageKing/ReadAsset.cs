using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageKing
{
    class ReadAsset
    {
        public List<string[]> LoadWords()
        {
            List<string[]> ret = new List<string[]>();
            try
            {
                var stream = Android.App.Application.Context.Assets.Open("words.csv");
                StreamReader sr = new StreamReader(stream);

                string line;
                string[] splitLine;

                while((line = sr.ReadLine()) != null)
                {
                    splitLine = line.Split(';');
                    ret.Add(splitLine);
                }

            }
            catch
            {

            }
            return ret;
        }
    }
}
