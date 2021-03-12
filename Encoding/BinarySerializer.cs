using System;
using System.Collections.Generic;
using System.IO;

namespace Blueprintz.Encoding {
    public class BinarySerializer : IDisposable
    {
        public List<string> items = new List<string>();

        public void Write(string value) => items.Add(value);
        public void Write(bool value) => items.Add(value.ToString());
        public void Write(int value) => items.Add(value.ToString());
        public void Write(float value) => items.Add(value.ToString());
        public void Write(double value) => items.Add(value.ToString());
        public void Write(decimal value) => items.Add(value.ToString());
        public void Write(uint value) => items.Add(value.ToString());

        public int GetFileIndex(string item)
        {
            for (int i = 0; i < items.Count; i++)
                if (items[i] == item) return i;
            return -1;
        }

        public void WriteToFile(string path)
        {
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
            foreach (string item in items) writer.Write(item);
        }

        public void Dispose() => items.Clear();
    }
}