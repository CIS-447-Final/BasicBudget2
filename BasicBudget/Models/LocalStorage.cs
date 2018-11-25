using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft;
using Newtonsoft.Json.Serialization;

namespace BasicBudget.Models
{
    public static class LocalStorage
    {

        public static void SaveData()
        {
            Dictionary<DateTime, MonthBudget> budget = Manager.MonthBudgets;
            Application.Current.Properties["LocalData"] = budget;
        }

        public static void SaveGUID(string newGUID = null)
        {
            // Assign the user the UUID from a previous account that they had
            if (!string.IsNullOrEmpty(newGUID))
            {
                Application.Current.Properties["GUID"] = newGUID;
            }

            if (!Application.Current.Properties.ContainsKey("GUID"))
            {
                Application.Current.Properties["GUID"] = Guid.NewGuid().ToString();
            }
        }


        public static string GetGUID()
        {
            return Application.Current.Properties["GUID"].ToString();
        }


        /// <summary>
        /// Serializes and returns the json serialized version of the MonthBudget dictionary
        /// </summary>
        /// <returns>A string of the budget as json serialized data</returns>
        public static string GetJsonData()
        {
            // Save the current data before retrieving that data.
            SaveData();

            // Load the data from local storage to be serialized and returned.
            Dictionary<DateTime, MonthBudget>  budget = (Dictionary<DateTime, MonthBudget>)Application.Current.Properties["LocalData"];
            string serializedBudget = JsonConvert.SerializeObject(budget);

            return serializedBudget;
        }

        /// <summary>
        /// Loads the MonthBudget data saved to local storage and returns it in its dictionary format.
        /// </summary>
        /// <returns>The MonthBudget as a dictionary</returns>
        public static Dictionary<DateTime, MonthBudget> GetDictData()
        {
            // Save the current data before retrieving that data.
            SaveData();

            Dictionary<DateTime, MonthBudget> budget = (Dictionary<DateTime, MonthBudget>)Application.Current.Properties["LocalData"];

            return budget;
        }


        public static 
    }
}
