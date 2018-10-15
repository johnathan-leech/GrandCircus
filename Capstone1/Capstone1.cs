using System;

namespace Capstone1
{
    class Capstone1
    {
        static string finalString = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator");

            TranslateToPigLatin(GetsUserInput());

            Console.WriteLine(finalString);
        }

        static string GetsUserInput()
        {
            Console.Write("Enter a line to be translated: ");
            string sentence;
            return sentence = Console.ReadLine().ToLower();
        }


        static void TranslateToPigLatin(string sentence)
        {
            string vowels = "aeiou";
            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {

                string firstLetter = word.Substring(0, 1);
                string secondLetter = word.Substring(1, 1);
                string thirdLetter = word.Substring(2, 1);

                string wordStem = word.Substring(1, word.Length - 1);
                string wordStem2 = word.Substring(2, word.Length - 2);
                string wordStem3 = word.Substring(3, word.Length - 3);

                int indexTestVowel = vowels.IndexOf(firstLetter);
                int indexTestVowel2 = vowels.IndexOf(secondLetter);
                int indexTestVowel3 = vowels.IndexOf(thirdLetter);

                if (indexTestVowel == -1)
                {
                    if (indexTestVowel2 == -1)
                    {
                        if (indexTestVowel3 == -1)
                        {
                            finalString += wordStem3 + firstLetter + secondLetter + thirdLetter + "ay ";
                        }
                        finalString += wordStem2 + firstLetter + secondLetter + "ay ";
                    }
                    else
                    {
                        finalString += wordStem + firstLetter + "ay ";
                    }
                }
                else if (indexTestVowel == 0)
                {
                    finalString += firstLetter + wordStem + "way ";
                }

            }

        }
    }
}
