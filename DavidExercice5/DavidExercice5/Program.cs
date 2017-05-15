using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DavidExercice5
{
    // create an application that read a textfile and trie les mots qu'il contient par ordre alphabetique
    //and the number of time that eacc word appears

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a text file Path");
            DisplayWords();
            Console.ReadLine();
        }

        private static void DisplayWords()
        {
            StreamReader myFile = new StreamReader(Console.ReadLine());
            string myString = myFile.ReadToEnd();

            myFile.Close();

            string[] words = myString.Split(' ');

            foreach (string word in words)
            {
                Console.WriteLine(word);
                int count = 0;
                foreach (Match match in Regex.Matches(myString, word, RegexOptions.IgnoreCase))
                {
                    count++;
                }
                Console.WriteLine("{0}" + " Found " + "{1}" + " Times", word, count);
            }

            IEnumerable<string> sortAscendingQuery =
             from word in words
             orderby word
             select word;

            Console.WriteLine("Ascending:");
            foreach (string item in sortAscendingQuery)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
