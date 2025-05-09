using System;
using urusaiBot.DiscordFolder;

namespace Program
{
    internal class Program
    {
        public static DiscordClass _discord;
        static void Main(string[] args)
        {
            _discord = new DiscordClass();
            Console.WriteLine("Добро пожаловать в urusaiBot!\n");
            GetCommand();
        }

        static void GetCommand()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Включить бота");
            Console.WriteLine("2. Отключить бота");
            Console.WriteLine("3. Выводить лог. Для отмены нажмите \"N\"");

            string key = Console.ReadLine();
            switch (key)
            {
                case "1":
                    StartDiscord();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Не верный символ! Повторите снова.");
                    GetCommand();
                    break;
            };
            GetCommand();
        }

        static void StartDiscord()
        {
            if(_discord.key.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Введите ссылку до txt файла с ключом от бота\n");
                string path = Console.ReadLine();
                _discord.key = _discord.GetKey(path);

                _discord.StartSettingBot();
            }
            _discord.StartBot();

            Console.Clear();
            Console.WriteLine("Бот успешно подключен!!\n");
        }
    }
}