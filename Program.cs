using System;
using System.Security.Cryptography;
using System.Threading;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }
        static bool paused = false;

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("DIGITE A SUA OPÇÃO:");
            Console.WriteLine("=> S - Para Segundos => 10s para 10 segundos");
            Console.WriteLine("=> M - Para Minutos => 1m para 1 minuto");
            Console.WriteLine("=> 0 - Para Sair");
            Console.WriteLine(" ");

            Console.WriteLine("Quantos tempo deseja contar? ");

            string data = Console.ReadLine().ToLower();
            char type = Convert.ToChar(data.Substring(data.Length - 1, 1));
            int time = Convert.ToInt32(data.Substring(0, data.Length - 1));
            int multiplier = 1;

            if (type == 'm')
                multiplier = 60;
            if (time == 0)
                System.Environment.Exit(0);

            PreStart(time * multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();

            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("Go...!!!");
            Thread.Sleep(2500);

            Start(time);
        }

        static void Start(int time)
        {
            Console.WriteLine("Digite um número");
            int currentTime = 0;
            Console.WriteLine("Pressione 'P' para pausar/continuar.");

            while (currentTime != time)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.P)
                    {
                        paused = !paused;

                        if (paused)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Cronômetro pausado.");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Pressione 'P' para continuar");
                            Console.WriteLine("Pressione 'R' para retorna ao menu inicial.");
                        }
                        else
                        {
                            Console.WriteLine("Cronômetro retomado.");
                        }

                    }

                    if (key == ConsoleKey.R)
                    {
                        Console.Clear();
                        Menu();
                        return;
                    }
                }

                if (!paused)
                {

                    Console.Clear();
                    Console.WriteLine("Pressione 'P' para pausar o Crônometro.");
                    Console.WriteLine(" ");
                    currentTime++;
                    Console.WriteLine(currentTime);
                    Thread.Sleep(1000);

                }

            }
            Console.Clear();
            Console.WriteLine("Stopwatch finalizado...");
            Thread.Sleep(2500);
            Menu();
        }



    }
}