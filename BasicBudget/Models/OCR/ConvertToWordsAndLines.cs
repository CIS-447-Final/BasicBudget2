using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ProjectOxford.Vision.Contract;

namespace BasicBudget.Models.OCR
{
    class ConvertToWordsAndLines
    {
        public static string[] GetExtracted(OcrResults res, bool words, bool mergeLines)
        {
            List<string> items = new List<string>();
            int reg = 1;

            foreach (Region r in res.Regions)
            {
                foreach (Line l in r.Lines)
                {
                    if (words)
                    {
                        items.AddRange(GetWords(l));
                    }
                    else
                    {
                        items.Add(GetLineAsString(l, mergeLines, reg));
                    }
                }

                reg++;
            }


            return items.ToArray();
        }


        private static List<string> GetWords(Line line)
        {
            List<string> words = new List<string>();

            foreach (Word w in line.Words)
            {
                words.Add(w.Text);
            }

            return words;
        }


        private static string GetLineAsString(Line line, bool mergeLines, int reg)
        {
            List<string> words = GetWords(line);
            string text = string.Join(" ", words);

            if (mergeLines)
            {
                text = line.Rectangle.Top.ToString() + "|" + text + "|" + reg.ToString();
            }

            return words.Count > 0 ? text : string.Empty;
        }
    }
}
