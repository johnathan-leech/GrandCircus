using System;

namespace Capstone1
{
    class Capstone1
    {
        static string finalString;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator");

            Console.Write("Enter a line to be translated: ");
            string sentence = Console.ReadLine().ToLower();


            string vowels = "aeiou";

            foreach (string words in sentence.Split())
            {
                string beginningLetter = sentence.Substring(0, 1);
                string stemOfWord = sentence.Substring(1, words.Length - 1);

                if (vowels.Contains(beginningLetter))
                {
                    finalString = words + "way ";
                }
                if (!(vowels.Contains(beginningLetter)))
                {
                    finalString = stemOfWord + beginningLetter + "ay ";
                }
            }



            //for (int i = 0; i < words.Length; i++)
            //{
            //    string beginningLetter = words[i].Substring(0,1);
            //    string stemOfWord = words[i].Substring(1, words.Length - 2);

            //    if (vowels.Contains(beginningLetter))
            //    {
            //        finalString = words[i] + "way ";
            //    }
            //    if (!(vowels.Contains(beginningLetter)))
            //    {
            //        finalString = stemOfWord + beginningLetter + "ay ";
            //    }
            //}
            Console.WriteLine(finalString);
        }
    }
}
