using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BasicBudget.Models.OCR
{
    class OCRProgram
    {
        //Returns the total in decimal form or 0.00 if an error occurs.
        public static decimal TextExtraction(Stream stream, bool words = false, bool mergeLines = true)
        {
            decimal totalValue = 0.00m;

            try
            {
                Task.Run(async () =>
                {
                    string[] res = await TextExtractionCore(stream, words, mergeLines);

                    if (mergeLines && !words)
                    {
                        res = MergingLines.MergeLines(res);
                    }

                    List<string> newRes = PersonalParsing.LineRemoval(res);
                    List<string> correctNumbers = PersonalParsing.ParseNumbersTogether(newRes);

                    totalValue = await Task.Run(() => Total.HighestAmount(correctNumbers.ToArray()));

                }).Wait();

                return totalValue;
            }
            catch
            {
                return totalValue;
            }

        }

        private static async Task<string[]> TextExtractionCore(Stream stream, bool words, bool mergeLines)
        {
            VisionServiceClient client = new VisionServiceClient("60ae256a757e424c8e286609305b9221", "https://westus.api.cognitive.microsoft.com/vision/v1.0");
            string[] textres = null;

            //if (File.Exists(fname))
            //{

            //using (Stream stream = File.OpenRead(fname))
            //{
            OcrResults res = await client.RecognizeTextAsync(stream, "unk", false);
            textres = ConvertToWordsAndLines.GetExtracted(res, words, mergeLines);
            stream.Close();
            stream.Dispose();
            //}
            //}

            return textres;
        }
    }
}
