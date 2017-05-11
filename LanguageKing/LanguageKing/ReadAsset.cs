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
        public List<string[]> LoadWords(int category)
        {
            List<string[]> ret = new List<string[]>();
            try
            {
                var stream = Android.App.Application.Context.Assets.Open(category.ToString() + ".csv");
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

        public List<string[]> LoadUiWords()
        {
            List<string[]> ret = new List<string[]>();
            try
            {
                var stream = Android.App.Application.Context.Assets.Open("ui.csv");
                StreamReader sr = new StreamReader(stream);

                string line;
                string[] splitLine;

                while ((line = sr.ReadLine()) != null)
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

        public string[,] LoadCategories()
        {
            try
            {
                var stream = Android.App.Application.Context.Assets.Open("categories.csv");
                StreamReader sr = new StreamReader(stream);
                List<string[]> rowList = new List<string[]>();

                string line;
                string[] splitLine;

                while ((line = sr.ReadLine()) != null)
                {
                    splitLine = line.Split(';');
                    rowList.Add(splitLine);
                }
                string[,] ret = new string[rowList.Count, rowList[0].Length];
                for (int j = 0; j < rowList.Count; j++)
                {
                    for (int k = 0; k < rowList[0].Length; k++)
                    {
                        ret[j, k] = rowList[j][k];
                    }
                }
                return ret;
            }
            catch
            {

            }
            return null;
        }

        public string[,] LoadLanguages()
        {
            try
            {
                var stream = Android.App.Application.Context.Assets.Open("language.csv");
                StreamReader sr = new StreamReader(stream);
                List<string[]> rowList = new List<string[]>();

                string line;
                string[] splitLine;

                while ((line = sr.ReadLine()) != null)
                {
                    splitLine = line.Split(';');
                    rowList.Add(splitLine);
                }
                string[,] ret = new string[rowList.Count, rowList.Count];
                for (int j = 0; j < rowList.Count; j++)
                {
                    for (int k = 0; k < rowList.Count; k++)
                    {
                        ret[j, k] = rowList[j][k];
                    }
                }
                return ret;
            }
            catch
            {

            }
            return null;
        }

        public string[] LoadLocales()
        {
            try
            {
                var stream = Android.App.Application.Context.Assets.Open("locales.csv");
                StreamReader sr = new StreamReader(stream);

                string[] splitLine;
                string line;

                line = sr.ReadLine();
                splitLine = line.Split(';');

                return splitLine;
            }
            catch
            {
                return null;
            }
        }
    }
}
