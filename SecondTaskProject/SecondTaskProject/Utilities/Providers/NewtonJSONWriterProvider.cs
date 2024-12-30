using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SecondTaskProject.Interfaces;
using SecondTaskProject.Models;
using ConsystJSON.Models;

namespace SecondTaskProject.Utilities.Providers
{
    internal class NewtonJSONWriterProvider : IWriter
    {
        public bool AddObjectToJSON<T>(T data, string fileName)
        {
            var reader = new ConsystJSONReaderProvider();
            var employees = reader.GetJSONObjects<T>(fileName);
            var output = string.Empty;

            if (employees != null)
            {
                employees.Add(data);
                output = JsonConvert.SerializeObject(employees, Formatting.Indented).ToString();
            }
            else
            {
                output = JsonConvert.SerializeObject(new List<T>() { data }, Formatting.None).ToString();
            }
            File.WriteAllText(fileName, output);

            return true;
        }
    }
}
