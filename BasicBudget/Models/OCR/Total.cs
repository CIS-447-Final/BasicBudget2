using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BasicBudget.Models.OCR
{
    class Total
    {
        public static decimal HighestAmount(string[] res)
        {
            string result = string.Empty;
            decimal highest = 0;

            Regex r = new Regex(@"\d+[.,]\d{1,2}");

            foreach (string l in res)
            {
                //Console.WriteLine(l);
                Match m = r.Match(l);

                // parse commas into periods and spaces into not spaces.
                string formattedValue = m.Value.Replace(",", ".");
                formattedValue = formattedValue.Replace(" ", string.Empty);

                // Convert the string into a decimal for comparision and possible assignment.
                decimal.TryParse(formattedValue, out decimal numberValue);

                if (m != null && m.Value != string.Empty && numberValue > highest)
                {
                    highest = numberValue;
                    result = formattedValue;
                }
            }

            return Convert.ToDecimal(result);
        }
    }
}
