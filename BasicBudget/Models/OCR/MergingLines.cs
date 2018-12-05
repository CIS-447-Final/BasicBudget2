using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicBudget.Models.OCR
{
    class MergingLines
    {
        public static string[] MergeLines(string[] lines)
        {
            SortedDictionary<int, string> dict = MergeLinesCore(lines);
            return dict.Values.ToArray();
        }

        private static SortedDictionary<int, string> MergeLinesCore(string[] lines)
        {
            SortedDictionary<int, string> dict = new SortedDictionary<int, string>();

            foreach (string l in lines)
            {
                string[] parts = l.Split('|');

                if (parts.Length == 3)
                {
                    int top = Convert.ToInt32(parts[0]);
                    string str = parts[1];
                    int region = Convert.ToInt32(parts[2]);

                    if (dict.Count > 0 && region != 10)
                    {
                        KeyValuePair<int, string> item = FindClosest(dict, top);

                        if (item.Key != -1)
                        {
                            dict[item.Key] = item.Value + " " + str;
                        }
                        else
                        {
                            dict.Add(top, str);
                        }
                    }
                    else
                    {
                        dict.Add(top, str);
                    }
                }
            }

            return dict;
        }


        private static KeyValuePair<int, string> FindClosest(SortedDictionary<int, string> dict, int top)
        {
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(-1, string.Empty);

            foreach (KeyValuePair<int, string> i in dict)
            {
                int diff = i.Key - top;

                if (Math.Abs(diff) <= 15)
                {
                    item = i;
                    break;
                }
            }

            return item;
        }
    }
}
