using System;

namespace Slagsmål
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            bool fighting = true;
            bool choosing = true;

            string fName = "";
            int fHP = 200;
            int fAttack = 100;

            string oName = "";
            int oHP = 200;
            int oAttack = 100;
            int round = 1;

            IntroText();

            while (choosing == true)
            {
                string fChoice = Console.ReadLine();
                if (fChoice == "1")
                {
                    fName = "WALTER";
                    fHP = 200;
                    fAttack = 100;
                    choosing = false;
                }
                else if (fChoice == "2")
                {
                    fName = "BIG FLOPPA";
                    fHP = 200;
                    fAttack = 100;
                    choosing = false;
                }
                else if (fChoice == "3")
                {
                    fName = "LINUS";
                    fHP = 200;
                    fAttack = 100;
                    choosing = false;
                }
                else { Console.WriteLine("PLEASE ENTER A VALID NUMBER [1-3]"); }
            }

            oName = "GORILLA";
            oHP = 200;
            oAttack = 100;

            Console.WriteLine();
            Console.WriteLine(fName);
            Console.ReadLine();
            Console.WriteLine("VS");
            Console.ReadLine();
            Console.WriteLine(oName);
            Console.ReadLine();

            while (fighting == true)
            {
                Console.WriteLine("ROUND " + round + "!");
                Console.WriteLine();

                oHP = Attack(generator, fAttack, fName, oHP);
                fHP = Attack(generator, oAttack, oName, fHP);
                round = NextRound(fName, oName, fHP, oHP, round);
                if (fHP <= 0 || oHP <= 0) { fighting = false; }
            }

            if (oHP <= 0 && fHP > 0) { Console.WriteLine(fName + " WINS!"); }
            else if (fHP <= 0 && oHP > 0) { Console.WriteLine(oName + " WINS!"); }
            else if (fHP <= 0 && oHP <= 0) { Console.WriteLine("IT'S A DRAW"); }
            Console.ReadLine();
        }

        static int Attack(Random generator, int attack, string fighter, int opHP)
        {
            int damage = generator.Next(1, 11) * attack / 10;
            Console.WriteLine(fighter + " ATTACKS!");
            Console.WriteLine(damage + " DAMAGE!");
            opHP = opHP - damage;
            return opHP;
        }

        static int NextRound(string fighterName, string opName, int fighterHP, int opHP, int round)
        {
            Console.WriteLine();
            Console.WriteLine(fighterName + ": " + fighterHP + " HP");
            Console.WriteLine(opName + ": " + opHP + " HP");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.ReadLine();
            round = round + 1;
            return round;
        }

        static void IntroText()
        {
            Console.WriteLine("WALTER BATTLE 2020");
            Console.WriteLine("Use [ENTER] to progress through the game");
            Console.ReadLine();
            Console.WriteLine("SELECT YOUR FIGHTER [1-3]");
            Console.WriteLine();

            Console.WriteLine("WALTER [1]");
            Console.WriteLine("HP: 200");
            Console.WriteLine("ATTACK: 100");
            Console.WriteLine();
            Console.WriteLine("BIG FLOPPA [2]");
            Console.WriteLine("HP: 300");
            Console.WriteLine("ATTACK: 80");
            Console.WriteLine();
            Console.WriteLine("LINUS TECH TIPS [3]");
            Console.WriteLine("HP: 150");
            Console.WriteLine("HP: 150");
            Console.WriteLine();
        }
    }
}
