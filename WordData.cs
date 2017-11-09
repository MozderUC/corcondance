using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concordance
{
    class WordData
    {
        public string WordValue { get; set; }
        public int LineNumber { get; set; }

        public WordData(string word, int line)
        {
            this.WordValue = word;
            this.LineNumber = line;
        }
    }
}
