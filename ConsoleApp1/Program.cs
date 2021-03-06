using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static Encoding encoding = Encoding.Default;
        static void Main(string[] args)
        {
            Console.Title = "File Cryptor by Neki_play";
            Console.WriteLine("Доступные действия:\n1. Зашифровать\n2. Расшифровать");
            Console.Write("Ваше действие: ");
            string ans = Console.ReadLine();
            Console.Write("Пароль: ");
            string pass = Console.ReadLine();
            Console.Write("Путь до файла: ");
            string file = Console.ReadLine().Replace("\"", "").Replace("'", "");
            if (ans == "1")
            {
                if (!CryptFile(file, pass, "Neki"))
                {
                    Console.WriteLine("Файл не найден пошел нахуй");
                }
            }
            else
            {
                if (!UncryptFile(file, pass, "Neki"))
                {
                    Console.WriteLine("Файл не найден пошел нахуй");
                }
            }
            Console.WriteLine("Процедура завершена");
            Console.ReadKey();
        }

        static bool CryptFile(string file, string password, string salt)
        {
            if (File.Exists(file))
            {
                byte[] bytes = File.ReadAllBytes(file);
                string text = encoding.GetString(bytes, 0, bytes.Length);
                Cryptor cryptor = new Cryptor();
                Reader reader = new Reader(file, ' ', encoding);
                string crypted = cryptor.Crypt(text, password, salt);
                reader.WriteBytesToFile(crypted);
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool UncryptFile(string file, string password, string salt)
        {
            if (File.Exists(file))
            {
                Reader reader = new Reader(file, ' ', encoding);
                string text = reader.ReadBytesFromFile();
                Cryptor cryptor = new Cryptor();
                string crypted = cryptor.Decrypt(text, password, salt);
                File.WriteAllBytes(file, encoding.GetBytes(crypted));
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
