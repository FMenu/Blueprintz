using System.IO;
using Blueprintz.Save;
using Newtonsoft.Json;

namespace Blueprintz.Encoding
{
    public class JsonEncoder
    {
        protected string rawJson = "";
        protected string json = "";

        public void Encode(SaveFile properties)
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
