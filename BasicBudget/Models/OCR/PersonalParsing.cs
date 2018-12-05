using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BasicBudget.Models.OCR
{
    class PersonalParsing
    {
        public static List<string> LineRemoval(string[] res)
        {
            string[] wordsToDelete = { "SUBTOTAL", "CASH", "CHANGE" };
            List<string> finalLines = res.ToList();

            foreach (var line in res)
            {
                foreach (var word in wordsToDelete)
                {
                    var modLine = line.ToUpper();

                    if (modLine.Contains(word))
                    {
                        Console.WriteLine("Found:" + modLine);
                        finalLines.Remove(line);
                    }
                }

            }

            List<string> words = ConvertLinesToWords(finalLines.ToArray());

            return words;
        }



        private static List<string> ConvertLinesToWords(string[] lines)
        {
            List<string> words = new List<string>();

            foreach (var l in lines)
            {
                // Create an array to hold each word from each line, then add each word to the "words" list
                string[] eachWord = l.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                words.AddRange(eachWord);
            }

            return words;
        }



        public static List<string> ParseNumbersTogether(List<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Contains("$"))
                {
                    // remove the $, then check if current word can be parsed to a number, then see if the next number is a number but with a decimal to start the string

                    string formattedWord = words[i].Replace("$", string.Empty);
                    formattedWord = formattedWord.Replace("o", "0");
                    formattedWord = formattedWord.Replace("O", "0");
                    bool firstSuccess = decimal.TryParse(formattedWord, out decimal number1);

                    if (firstSuccess)
                    {
                        //Regex requirement = new Regex(@"^\.{1}\d{2}$");
                        Regex requirement = new Regex(@"^\.");
                        bool passed = requirement.IsMatch(words[i + 1]);

                        if (passed)
                        {
                            string nextFormattedWord = words[i + 1].Replace("O", "0");
                            nextFormattedWord = nextFormattedWord.Replace("o", "0");

                            // Combine the words into the first item, and delete the next item.
                            words[i] = formattedWord + nextFormattedWord;
                            words.RemoveAt(i + 1);
                        }
                    }
                }
            }

            return words;
            //Console.WriteLine("Highest amount: " + HighestAmount(words.ToArray()));
        }
    }
}
