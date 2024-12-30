using SecondTaskProject.Interfaces;
using ConsystJSON;
using SecondTaskProject.Models;

namespace SecondTaskProject.Utilities.Providers
{
    internal class ConsystJSONReaderProvider : IReader
    {
        public List<T> GetJSONObjects<T>(string filePath) 
        {
            try
            {
                var jsonData = File.ReadAllText(filePath);
                var jsonObjects = JsonConverter.DeserializeArray<T>(jsonData);

                return jsonObjects;
            }
            catch (Exception e)
            {
                return new List<T>();
            }
        }
    }
}
