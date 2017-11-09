using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concordance
{
    class Concordance
    {
        protected class ConcordanceData
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
                string str = "";
                foreach (int i in ArrOfLine)
                    str = str + Convert.ToString(i) + " ";

                return WordValue + " " + Convert.ToString(NumberInText) + " " + str;
            }
        }

        List<WordData> wordData = new List<WordData>();
        IEnumerable<ConcordanceData> concordanceData;

        public void GetData(string Path)
        {
            wordData = Parser.Parse(Path);
        }
        public void MakeCorcondance()
        {
            var GroupWords =
                    from word in wordData
                    group word by word.WordValue into newGroup
                    orderby newGroup.Key
                    select newGroup;
            concordanceData = GroupWords.Select(x => new ConcordanceData { WordValue = x.Key, NumberInText = x.Count(), ArrOfLine = new HashSet<int>(x.Select(y => y.LineNumber)) });          
        }
         public string DisplayData()
        {
            string str = "";
            foreach(var data in concordanceData)
            {
                str = str + data.ToString()+"\n";
            }
            return str;
        }
    }
}
