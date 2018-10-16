using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pig Latin Translator");

        do
        {
            string userInput = GetsUserInput();
            // if statement validates that a word/sentence was entered.
            // if so, it goes on to translate the sentence to piglatin
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Enter a word or sentence.");
            }
            else
            {
                TranslateToPigLatin(userInput);
                if (PromptUserToContinue() == false)
                {
                    break;
                }
            }
        } while (true);
    }

    static string GetsUserInput()
    {
        Console.Write("Enter a line to be translated: ");
        return Console.ReadLine().ToLower();
    }

    static void TranslateToPigLatin(string sentence)
    {
        string vowels = "aeiou";
        List<string> words = new List<string>();
        List<string> finalString = new List<string>();
        // splits sentence to individual words
        words = sentence.Split(' ').ToList();

        // iterates through each individual word 
        foreach (string word in words)
        {
            int length = word.Length;
            string newWord = word;

            /* iterates through the letters in the separate words,
               in order to see if a consonant needs to be "popped" and
               then added to the end. If it's a vowel "way" is simply added.
            */
            for (int i = 0; i < length; i++)
            {
                char letter = word[i];
                bool isVowel = vowels.Contains(letter);

                // starts w/ a vowel
                if (isVowel && i == 0)
                {
                    finalString.Add(newWord + "way");
                    break;
                }
                // is currently a vowel
                if (isVowel && i > 0)
                {
                    finalString.Add(newWord + "ay");
                    //finalString.Append<string>(newWord + "ay");
                    break;
                }
                // or it must be a consonant
                if (!isVowel)
                {
                    newWord = newWord.Remove(0, 1);
                    newWord = newWord + letter;
                }
            }
        }
        // takes each individual word and joins it to "finalString"
        // and outputs the string value
        Console.WriteLine(String.Join(" ", finalString));
    }

    static bool PromptUserToContinue()
    {
        while (true)
        {
            Console.WriteLine("Translate another line? (y/n): ");
            string loopAgain = Console.ReadLine().ToLower();
            if (loopAgain == "y")
            {
                return true;
            }
            else if (loopAgain == "n")
            {
                return false;
            }

            Console.WriteLine("Only enter 'y' or 'n'.");
        }
    }
}