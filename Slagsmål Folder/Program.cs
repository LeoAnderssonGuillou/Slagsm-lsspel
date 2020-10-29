using System;

namespace Slagsmål
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            bool playing = true;
            bool choosing = true;
            bool proceed = false;

            string fChoice = "";
            string fName = "";
            int fHP = 0;
            int fAttack = 0;
            string fMove1 = "";
            string fMove2 = "";

            string oName = "";
            int oHP = 0;
            int oAttack = 0;

            IntroText();
            while (playing == true)
            {
                FighterSelect();
                choosing = true;
                while (choosing == true)
                {
                    fChoice = Console.ReadLine();
                    if (fChoice == "1")
                    {
                        fName = "WALTER";
                        fHP = 300;
                        fAttack = 100;
                        choosing = false;
                        fMove1 = "BONK";
                        fMove2 = "WAR CRIME";
                    }
                    else if (fChoice == "2")
                    {
                        fName = "BIG FLOPPA";
                        fHP = 400;
                        fAttack = 85;
                        choosing = false;
                        fMove1 = "HISS";
                        fMove2 = "ROAST";
                    }
                    else if (fChoice == "3")
                    {
                        fName = "LINUS";
                        fHP = 200;
                        fAttack = 200;
                        choosing = false;
                        fMove1 = "DROP";
                        fMove2 = "STARE";
                    }
                    else { Console.WriteLine("PLEASE ENTER A VALID NUMBER [1-3]"); }
                }

                oName = "GORILLA";
                oHP = 200;
                oAttack = 100;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Versus(fName, oName);
                Console.ForegroundColor = ConsoleColor.White;
                proceed = Battle(oHP, fHP, fName, oName, fMove1, fMove2, generator, fAttack, oAttack);
                Console.WriteLine();

                if (proceed == true)
                {
                    oName = "OBAMA";
                    oHP = 200;
                    oAttack = 100;

                    Console.ReadLine();
                    Console.WriteLine("A NEW CHALLENGER APPROACHES!");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Versus(fName, oName);
                    proceed = Battle(oHP, fHP, fName, oName, fMove1, fMove2, generator, fAttack, oAttack);
                }
                if (proceed == true)
                {
                    oName = "BIG CHUNGUS";
                    oHP = 200;
                    oAttack = 100;

                    ChungusIntro();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Versus(fName, oName);
                    proceed = Battle(oHP, fHP, fName, oName, fMove1, fMove2, generator, fAttack, oAttack);
                }
                if (proceed == true)
                {
                    Console.ReadLine();
                    Console.WriteLine("THE EVIL REIGN OF CHUNGUS IS FINALLY OVER.");
                    Console.WriteLine("CITZENS NO LONGER HAVE TO PAY THEIR TAXES IN REDDIT GOLD");
                    Console.WriteLine("AND WALTER MAY EAT HIS CHEESBORG IN PIECE.");
                    Console.ReadLine();
                    playing = false;
                }
                else
                {
                    Console.WriteLine(fName + " IS UNABLE TO BATTLE");
                    Console.ReadLine();
                    Console.WriteLine("BUT YOU CANNOT GIVE UP JUST YET! STAY DETERMINED...");
                    Console.WriteLine("TRY AGAIN? [Y/N]");
                    string tryAgain = Console.ReadLine();
                    if (tryAgain == "Y" || tryAgain == "y" || tryAgain == "YES" || tryAgain == "yes")
                    {
                        playing = true;
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine();
                    }
                    else
                    {
                        playing = false;
                    }
                }
            }
        }

        static bool Battle(int opHP, int fiHP, string fighter, string opponent, string move1, string move2, Random gene, int fAtk, int oAtk)
        {
            bool fighting = true;
            int round = 1;
            string move;
            while (fighting == true)
            {
                Console.WriteLine("ROUND " + round + "!");
                Console.WriteLine();

                Console.WriteLine("WHAT WILL " + fighter + " DO? [1-2]");
                move = Console.ReadLine();
                if (move == "1")
                {
                    Console.WriteLine(fighter + " USED " + move1);
                    opHP = Attack(gene, fAtk, 95, fighter, opHP);
                }
                else if (move == "2")
                {
                    fAtk = fAtk * 2;
                    Console.WriteLine(fighter + " USED " + move2);
                    opHP = Attack(gene, fAtk, 55, fighter, opHP);
                }
                else
                {
                    Console.WriteLine("INVALID INPUT. " + fighter + " GOT CONFUSED AND COULDN'T ATTACK!");
                }

                Console.WriteLine(opponent + " ATTACKS!");
                fiHP = Attack(gene, oAtk, 95, opponent, fiHP);

                round = NextRound(fighter, opponent, fiHP, opHP, round);
                if (fiHP <= 0 || opHP <= 0) { fighting = false; }
            }

            if (opHP <= 0 && fiHP > 0)
            {
                Console.WriteLine(fighter + " WINS!");
                return true;
            }
            else if (fiHP <= 0 && opHP > 0) { Console.WriteLine(opponent + " WINS!"); return false; }
            else { Console.WriteLine("IT'S A DRAW!"); return false; }
        }

        static int Attack(Random generator, int attack, int accuracy, string fighter, int opHP)
        {
            int damage = generator.Next(5, 11) * attack / 10;
            int unlucky = generator.Next(1, 101);
            if (unlucky > accuracy)
            {
                damage = 0;
                Console.WriteLine("MISS!");
            }
            else
            {
                Console.WriteLine(damage + " DAMAGE!");
            }
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
            Console.WriteLine("USE [ENTER] TO PROGRESS THROUGH THE GAME.");
            Console.ReadLine();
            Console.WriteLine("EACH FIGHTER HAS TWO ATTACKS, [1] AND [2].");
            Console.WriteLine("[1] IS A SAFE BET, WHILE [2] DOES TWICE THE DAMAGE WITH A 45% CHANCE OF MISSING.");
            Console.ReadLine();
        }

        static void FighterSelect()
        {
            Console.WriteLine("SELECT YOUR FIGHTER [1-3]");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WALTER [1]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("HP: 300");
            Console.WriteLine("ATTACK: 100");
            Console.WriteLine("MOVES: BONK / WAR CRIME");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("BIG FLOPPA [2]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("HP: 400");
            Console.WriteLine("ATTACK: 80");
            Console.WriteLine("MOVES: HISS / ROAST");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("LINUS TECH TIPS [3]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("HP: 200");
            Console.WriteLine("ATTACK: 200");
            Console.WriteLine("MOVES: DROP / STARE");
            Console.WriteLine();
        }

        static void Versus(string fighter, string opponent)
        {
            Console.WriteLine(fighter);
            Console.ReadLine();
            Console.WriteLine("VS");
            Console.ReadLine();
            Console.WriteLine(opponent);
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------");

        }

        static void ChungusIntro()
        {
            Console.ReadLine();
            Console.WriteLine("AN OMNIOUS BREEZE IS SUDDENLY FELT THROUGH THE AIR");
            Console.ReadLine();
            Console.WriteLine("LIGHTNING STRIKES");
            Console.ReadLine();
            Console.WriteLine("THE EARTH TREMBLES");
            Console.ReadLine();
            Console.WriteLine("YOU HEAR THE CHANTS OF AN ARMY OF REDDITORS");
            Console.ReadLine();
            Console.WriteLine("WHOLESOME 100! WHOLESOME 100!");
            Console.ReadLine();
            Console.WriteLine("H E  HAS ARRIVED");
            Console.ReadLine();
        }
    }
}
