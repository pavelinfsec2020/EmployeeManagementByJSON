using SecondTaskProject.Interfaces;
using Newtonsoft.Json;

namespace SecondTaskProject.Utilities.Providers
{
    internal class NewtonJSONReadeProvider : IReader
    {
        public List<T> GetJSONObjects<T>(string filePath)
        {
            try
            {
                var jsonData = File.ReadAllText(filePath);
                var jsonObjects = JsonConvert.DeserializeObject<List<T>>(jsonData);

                return jsonObjects;
            }
            catch (Exception e)
            {
                return new List<T>();
            }
        }
    }
}
