using Newtonsoft.Json.Bson;
using System.IO;

namespace Blueprintz.Decoding
{
    public class BsonDeserializer<T>
    {
        private string bson = null;
        private T decoded;

        public bool LoadFromFile(string path)
        {
            try
            {
                bson = File.ReadAllText(path);
                return true;
            }
            catch { return false; }
        }

        public bool Decode(string bson)
        {
            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(bson);
                MemoryStream ms = new MemoryStream(data);
                using (BsonReader reader = new BsonReader(ms))
                {
                    Newtonsoft.Json.JsonSerializer serializer =
                        new Newtonsoft.Json.JsonSerializer();
                    decoded = serializer.Deserialize<T>(reader);
                }
                return true;
            }
            catch { return false; }
        }

        public T GetDecoded() => decoded;
        public override string ToString() => bson;
    }
}
