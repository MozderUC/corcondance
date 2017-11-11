using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace concordance
{
    class Parser
    {
        static public List<WordData> Parse(string Path)
        {
            List<WordData> words = new List<WordData>();                                  
            string[] lines = File.ReadAllLines(Path, Encoding.UTF8);

            int i = 0;
            foreach (string line in lines)
            {
                string[] source = line.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\n', '\r', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string w in source)
                {
                    if (Char.IsNumber(w[0]))
                    {
                        continue;
                    }
                    words.Add(new WordData(w, i + 1));
                }
                i++;
            }
            return words;
        }
    }
}
