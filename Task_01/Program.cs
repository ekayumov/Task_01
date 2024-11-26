using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Collections;
using System.Globalization;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name_user = "", text_comand = "";
            String full_cosmmand = "/help,/start,/info,/exit";
            bool active_echo = false;
            Console.WriteLine("Привет!!!");

            while (text_comand != "/exit")
            {
                if (name_user != "") { Console.WriteLine("Поработаем, " + name_user + "?)"); }
                Console.WriteLine("Cписок доступных команд: " + full_cosmmand);
                Console.WriteLine("Введитие команду");
                text_comand = Console.ReadLine();
                if (active_echo && text_comand.Split(' ')[0] == "/echo")
                {
                    Console.WriteLine(text_comand.Substring("/echo ".Length));
                    continue;
                }
                switch (text_comand)
                {
                    case "/start":
                        Console.WriteLine("");
                        Console.WriteLine("введите имя");
                        name_user = Console.ReadLine();
                        while (name_user == "")
                        {
                            Console.WriteLine("имя не может быть пустым,введите имя повторно!!!");
                            name_user = Console.ReadLine();
                        }
                        if (active_echo == false)
                        {
                            full_cosmmand += ",/echo {ваш текст}";
                            active_echo = true;
                        }
                        break;
                    case "/help":
                        Console.WriteLine("");
                        Console.WriteLine("1. Приветствие: При запуске программы отображается сообщение приветствия со списком доступных команд: / start, / help, / info, / exit.");
                        Console.WriteLine("2. Обработка команды / start: Если пользователь вводит команду / start, программа просит его ввести своё имя.Сохраните введенное имя в переменную.Программа должна обращаться к пользователю по имени в каждом следующем ответе.");
                        Console.WriteLine("3. Обработка команды / help: Отображает краткую справочную информацию о том, как пользоваться программой.");
                        Console.WriteLine("4. Обработка команды / info: Предоставляет информацию о версии программы и дате её создания.");
                        Console.WriteLine("5. Доступ к команде / echo: После ввода имени становится доступной команда / echo.При вводе этой команды с аргументом(например, / echo Hello), программа возвращает введенный текст(в данном примере \"Hello\").");
                        Console.WriteLine("6. Основной цикл программы: Программа продолжает ожидать ввод команды от пользователя, пока не будет введена команда / exit");
                        Console.WriteLine("");
                        break;
                    case "/info":
                        Console.WriteLine("");
                        Console.WriteLine("Version = " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                        Console.WriteLine("Дата создания проекта: 26.11.2024");
                        Console.WriteLine("");
                        break;
                    case "/exit":
                        Console.WriteLine("удачи! " + name_user);
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("такой команды несущеструет");
                        Console.WriteLine("");
                        break;
                }
            }
        }
    }
}
