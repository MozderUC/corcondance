using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concordance
{
    class Concordance
    {
        private class ConcordanceData
        {
            public string WordValue { get; set; }
            public int NumberInText { get; set; }
            public HashSet<int> ArrOfLine { get; set; }

            #region constructors
            public ConcordanceData()
            {

            }
            public ConcordanceData(string data, int numb, HashSet<int> arr)
            {
                this.WordValue = data;
                this.NumberInText = numb;
                this.ArrOfLine = arr;

            }
            #endregion

            public override string ToString()
            {
                int N = 20;
                String repeatedString;

                string str = "";
                foreach (int i in ArrOfLine)
                    str = str + Convert.ToString(i) + " ";

                try
                {
                    repeatedString = new String('.', N - WordValue.Count());
                }
                catch { repeatedString = "."; }
                

                return WordValue + repeatedString + Convert.ToString(NumberInText) + ": " + str;
            }
        }

        private List<WordData> wordData = new List<WordData>();
        private IEnumerable<ConcordanceData> concordanceData;

        public void GetData(string Path)
        {
            wordData = Parser.Parse(Path);
        }
        public void MakeCorcondance()
        {
            var GroupWords =
                    from word in wordData
                    group word by word.WordValue.ToLowerInvariant() into newGroup
                    orderby newGroup.Key
                    select newGroup;
            concordanceData = GroupWords
                              .Select(x => new ConcordanceData { WordValue = x.Key, NumberInText = x.Count(), ArrOfLine = new HashSet<int>(x.Select(y => y.LineNumber)) });          
        }
        
        public string GetCorcondanceString()
        {
            string str = "";
            char ch = ' ';

            foreach (var data in concordanceData)
            {
                if(data.WordValue[0]!=ch)
                {
                    ch = data.WordValue[0];
                    str = str + "\n"+ Char.ToUpper(ch) + "\n" + data.ToString() + "\n" ;
                    continue;
                }

                str = str + data.ToString() + "\n";
            }
            return str;
        }
        public void SaveCorcondanceToFile(string path)
        {
            System.IO.File.WriteAllText(path, GetCorcondanceString());
        }

    }
}
