using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader
    {
        private string path { get; }
        private Encoding encoding = Encoding.Unicode;
        private char writer = ' ';
        public Reader(string path, char writer, Encoding encoding)
        {
            this.path = path;
            this.writer = writer;
            this.encoding = encoding;
        }

        public string ReadBytesFromFile()
        {
            if (File.Exists(path))
            {
                List<byte> byt = new List<byte>();
                using (StreamReader reader = new StreamReader(path))
                {
                    string text = reader.ReadToEnd();
                    foreach (string a in text.Split(writer))
                    {
                        byt.Add(Convert.ToByte(a));
                    }

                    reader.Close();
                }
                string readed = encoding.GetString(byt.ToArray(), 0, byt.Count);
                return readed;
            }
            else
            {
                return string.Empty;
            }
        }
        public void WriteBytesToFile(string text)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            byte[] aa = encoding.GetBytes(text);
            File.WriteAllText(path, string.Join(writer.ToString(), aa));
        }
    }
}
