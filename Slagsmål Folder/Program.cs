using System;

namespace Slagsmål
{
    class Program
    {
        static void Main(string[] args)
        {
            //Boolean variables controlling the flow of the game through while-loops
            Random generator = new Random();
            bool playing = true;
            bool choosing = true;
            bool proceed = false;

            //Variables relating to the player
            string fChoice = "";
            string fName = "";  //Name of the chosen fighter
            int fHP = 0;        //Hit points (HP) of the chosen fighter
            int fAttack = 0;    //Attack stat of the chosen fighter
            string fMove1 = ""; //Name of the chosen fighter's first move
            string fMove2 = ""; //Name of the chosen fighter's second move

            //Variables relating to the opponent
            string oName = "";
            int oHP = 0;
            int oAttack = 0;

            IntroText();    //Writes out the game's introduction
            while (playing == true)
            {
                FighterSelect();    //Writes out the fighter options
                choosing = true;
                while (choosing == true)    //Loop forcing player to enter a valid choice [1-3]
                {
                    fChoice = Console.ReadLine();
                    if (fChoice == "1")     //Applies the stats of the chosen fighter
                    {
                        fName = "WALTER";
                        fHP = 300;
                        fAttack = 100;
                        fMove1 = "BONK";
                        fMove2 = "WAR CRIME";
                        choosing = false;
                    }
                    else if (fChoice == "2")
                    {
                        fName = "BIG FLOPPA";
                        fHP = 400;
                        fAttack = 85;
                        fMove1 = "HISS";
                        fMove2 = "ROAST";
                        choosing = false;
                    }
                    else if (fChoice == "3")
                    {
                        fName = "LINUS";
                        fHP = 200;
                        fAttack = 200;
                        fMove1 = "DROP";
                        fMove2 = "STARE";
                        choosing = false;
                    }
                    else { Console.WriteLine("PLEASE ENTER A VALID NUMBER [1-3]"); }
                }

                //The first opponent's stats are applied and "fighter VS opponent" is written out in Yellow
                oName = "GORILLA";
                oHP = 200;
                oAttack = 100;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Versus(fName, oName);

                //The Battle method it what handles most of the game, that is the actual fighting. All the properties of the fighter
                //and opponent are used, as well as the names of the opponents two moves. If the player wins the value true is returned
                //and the game moves on to the next battle.
                proceed = Battle(oHP, fHP, fName, oName, fMove1, fMove2, generator, fAttack, oAttack, "MONKEY FLIP", "SPINNING GORILLA");
                Console.WriteLine();

                if (proceed == true)    //The opponents properties are changed for the next battle, and the Versus and Battle methods are repeated.
                {
                    oName = "OBAMA";
                    oHP = 250;
                    oAttack = 150;

                    Console.ReadLine();
                    Console.WriteLine("A NEW CHALLENGER APPROACHES!");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Versus(fName, oName);
                    proceed = Battle(oHP, fHP, fName, oName, fMove1, fMove2, generator, fAttack, oAttack, "NWORD", "HIS LAST NAME");
                }
                if (proceed == true)    //Properties are changed for the final battle
                {
                    oName = "BIG CHUNGUS";
                    oHP = 300;
                    oAttack = 200;

                    ChungusIntro();     //The battle has its own intro, and used red instead of yellow.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Versus(fName, oName);
                    proceed = Battle(oHP, fHP, fName, oName, fMove1, fMove2, generator, fAttack, oAttack, "CHUNGUS BLAST", "THAT'LL HOLD EM ALRIGHT");
                }
                if (proceed == true)    //If all battles have been won, some final text is written out and the game ends.
                {
                    Console.ReadLine();
                    Console.WriteLine("THE EVIL REIGN OF CHUNGUS IS FINALLY OVER.");
                    Console.WriteLine("CITIZENS NO LONGER HAVE TO PAY THEIR TAXES IN REDDIT GOLD");
                    Console.WriteLine("AND WALTER MAY EAT HIS CHEESEBORG IN PIECE.");
                    Console.ReadLine();
                    playing = false;
                }
                else    //If any battle is lost, the player loses and may either choose to try again or end the game.
                {
                    Console.WriteLine(fName + " IS UNABLE TO BATTLE");
                    Console.ReadLine();
                    Console.WriteLine("BUT YOU CANNOT GIVE UP JUST YET! STAY DETERMINED...");
                    Console.WriteLine("TRY AGAIN? [Y/N]");
                    string tryAgain = Console.ReadLine();
                    if (tryAgain == "Y" || tryAgain == "y" || tryAgain == "YES" || tryAgain == "yes")
                    {
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

        //The Battle method functions through a while-loop, where each cycle is a round in-game. It lets the player choose
        //between two attacks, that generate different outcomes by giving the Attack method different damage and accuracy values.
        //Instead of forcing the player to give a valid input, the chance to attack is lost if an invalid input is given.
        static bool Battle(int opHP, int fiHP, string fighter,
        string opponent, string move1, string move2, Random gene, int fAtk, int oAtk, string opMove1, string opMove2)
        {
            bool fighting = true;
            int round = 1;
            string move;
            int opMove;
            while (fighting == true)
            {
                Console.WriteLine("ROUND " + round + "!");
                Console.WriteLine();

                Console.WriteLine("WHAT WILL " + fighter + " DO? [1-2]");
                move = Console.ReadLine();
                if (move == "1")
                {
                    Console.WriteLine(fighter + " USES " + move1 + "!");
                    opHP = Attack(gene, fAtk, 95, fighter, opHP);
                }
                else if (move == "2")
                {
                    fAtk = fAtk * 2;
                    Console.WriteLine(fighter + " USES " + move2 + "!");
                    opHP = Attack(gene, fAtk, 60, fighter, opHP);
                }
                else
                {
                    Console.WriteLine("INVALID INPUT. " + fighter + " GOT CONFUSED AND COULDN'T ATTACK!");
                }

                opMove = gene.Next(1, 3);
                if (opMove == 1)
                {
                    Console.WriteLine(opponent + " USES " + opMove1 + "!");
                }
                else
                {
                    Console.WriteLine(opponent + " USES " + opMove2 + "!");
                }
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

        //The Attack method calculates and writes out the damage of an attack and returns its victims HP.
        //It does this with the help of a Random variable as well as the attack and accuracy stats provided by the Battle method.
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

        //Function writes out part of the structure of each round and returns the value of the next round.
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
            Console.WriteLine("[1] IS A SAFE BET, WHILE [2] DOES TWICE THE DAMAGE WITH A 40% CHANCE OF MISSING.");
            Console.ReadLine();
        }

        static void FighterSelect()
        {
            Console.WriteLine("SELECT YOUR FIGHTER [ENTER 1-3]");
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
            Console.WriteLine("AN OMNOUS BREEZE IS SUDDENLY FELT THROUGH THE AIR");
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
