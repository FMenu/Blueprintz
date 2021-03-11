using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.IO;

namespace Blueprintz.Encoding
{
    public static class BinaryEncoder
    {
        public static string EncodeFromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject(json);
            JsonSerializer serializer = new JsonSerializer();
            MemoryStream stream = new MemoryStream();
            BsonWriter writer = new BsonWriter(stream);
            serializer.Serialize(writer, obj);
            return System.Text.Encoding.ASCII.GetString(stream.ToArray());
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
}
