using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit.Sdk;

namespace JsonFileManager
{
    public class Manager
    {
        //Json till Dictionary 

        // Dictionary till JSon
        public string CreateJsonFromDict(Dictionary<string, object> dict)
        {
            if (!dict.Any())
            {
                throw new ArgumentException();
            }



            return JsonConvert.SerializeObject(dict);

            
        }


        // Läsa json fil

        // Skriva till json fil



    }
}
