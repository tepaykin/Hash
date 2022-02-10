using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main ()
        {
            Console.WriteLine("Зарегистрируйте пользователя \n введите Login");
            string  login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();
            string contentHash = Protector.Hash(login, password);

            Console.WriteLine($"шифрованный текст: \n {contentHash}");

            Console.WriteLine("Авторизация - введите логин ");
            string loginGosty = Console.ReadLine();
            Console.WriteLine("Авторизация - введите пароль ");
            string passwordGosty = Console.ReadLine();
            string HashGosty = Protector.Hash(loginGosty, passwordGosty);

            if (HashGosty == contentHash)
            {
                Console.WriteLine("Это наш юзер ");
            }
            else
            {
                Console.WriteLine("Это не наш юзер ");

            }
        }
    }
   public static class Protector
    {
        public static string Hash(string content, string content2)
        {
            var saltText = "7BANANAS0";
            var saltedhashedPassword = SaltAndHash(content2, saltText);

            return saltedhashedPassword;
        }
        private static string SaltAndHash(string content2, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = content2 + salt;
            return Convert.ToBase64String(sha.ComputeHash (Encoding.Unicode.GetBytes (saltedPassword)));
        }
    }
}
