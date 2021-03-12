using System.IO;
using Newtonsoft.Json;

namespace Blueprintz.Encoding
{
    public class JsonSerializer<T>
    {
        protected string rawJson = "";
        protected string json = "";

        public void Encode(T properties)
        {
            rawJson = JsonConvert.SerializeObject(properties, Formatting.None);
            json = JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public bool WriteToFile(string path, bool formatted)
        {
            try
            {
                if (formatted)
                    File.WriteAllText(path, json);
                else File.WriteAllText(path, rawJson);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetFormatted() => json;
        public override string ToString() => rawJson;
    }
}
