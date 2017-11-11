using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concordance
{
    class Program
    {
        static void Main(string[] args)
        {

            Concordance concordance = new Concordance();
            concordance.GetData("text.txt");
            concordance.MakeCorcondance();

            concordance.SaveDataToFile("outputData.txt");
            string str = concordance.DisplayData();
            Console.WriteLine(str);
        }
    }
}
