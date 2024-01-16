using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit.Sdk;

namespace JsonFileManager
{
    public class Manager
    {
        //Json till Dictionary 

        // Dictionary till JSon
        public string CreateJsonFromDict(Dictionary<string, object> dict)
        {

            if(dict == null)
                throw new ArgumentNullException();
            else if (!dict.Any())        
                throw new ArgumentNullException();
            else if (dict.ContainsValue(null))
                throw new NullReferenceException();

            return JsonConvert.SerializeObject(dict);   
        }

        // Skriva till json fil
        public void WriteJsonToFile(string json, string fileName)
        {
            if (IsValidJson(json))
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                System.IO.File.WriteAllText(fileName, json);
            }
            
        }

        /// <summary>
        /// Validates a string as Json. If invalid Json, this method will throw an JsonReaderException.
        /// </summary>
        /// <param name="stringToValidate"></param>
        /// <returns>Returns: True if the input string is correct JSON format, Otherwise this will throw a JsonReaderException.</returns>
        /// <exception cref="JsonReaderException"></exception>"
        private bool IsValidJson(string stringToValidate)
        {
                JToken.Parse(stringToValidate);
                return true;
        }   

        // Läsa json fil

        



    }
}
