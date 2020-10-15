﻿using System;

namespace Slagsmål
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            bool fighting = true;
            int wHP = 200;
            int gHP = 200;
            int wAttack = 0;
            int gAttack = 0;
            int round = 1;

            Console.WriteLine("Walter VS Gorilla!");

            while (fighting == true)
            {
                Console.WriteLine("ROUND " + round + "!");
                Console.WriteLine();

                wAttack = generator.Next(1, 51);
                Console.WriteLine("Walter attacks!");
                Console.WriteLine(wAttack + " damage!");
                gHP = gHP - wAttack;
                Console.WriteLine();

                gAttack = generator.Next(1, 51);
                Console.WriteLine("Gorilla attacks!");
                Console.WriteLine(gAttack + " damage!");
                wHP = wHP - gAttack;
                Console.WriteLine();

                Console.WriteLine("Walter: " + wHP + " HP");
                Console.WriteLine("Gorilla: " + gHP + " HP");
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                Console.ReadLine();
                round = round + 1;
            }
        }
    }
}
