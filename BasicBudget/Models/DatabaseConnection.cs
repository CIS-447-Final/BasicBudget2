using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BasicBudget.Models
{
    public static class DatabaseConnection
    {
        public static bool Upload()
        {
            string url = "https://basicbudgetdbconnection.azurewebsites.net/api/BudgetData/";
            string path = $"{LocalStorage.GetGUID()}/{LocalStorage.GetJsonData()}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = client.PostAsync(path, null).Result;

            // Check to see if the post went through to the server
            if (response.IsSuccessStatusCode)
            {
                // Return whether or not the post was successful
                return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return false;
            }
        }

        public static void Download()
        {
            string url = "https://basicbudgetdbconnection.azurewebsites.net/api/BudgetData/";
            string path = $"{LocalStorage.GetGUID()}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                var budgets = JsonConvert.DeserializeObject<Dictionary<DateTime, MonthBudget>>(dataObjects);
                Manager.MonthBudgets = budgets;
                LocalStorage.SaveData();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        static void DeserializeDownloadData()
        {
            
        }

    }
}
