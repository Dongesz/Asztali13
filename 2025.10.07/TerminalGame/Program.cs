using System;
using System.Collections.Generic;

namespace TerminalGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Terminal RPG!");

            Player player = ChoosePlayerClass();

            List<Enemy> enemies = new List<Enemy>
            {
                new Zombie("Zombie", 120, 20, 10),
                new Wolf("Wolf", 130, 25, 8),
                new Golem("Golem", 250, 30, 25)
            };

            Console.Write("How many rounds would you like to fight? ");
            int totalRounds = int.Parse(Console.ReadLine() ?? "1");

            int wins = 0;
            
            for (int round = 1; round <= totalRounds; round++)
            {
                Console.WriteLine($"\n--- Round {round} ---");

                Enemy enemy = enemies[new Random().Next(enemies.Count)];
                enemy.resetStats();
                Console.WriteLine($"{enemy.Name} appears!");

                bool playerTurn = false;

                while (player.Hp > 0 && enemy.Hp > 0)
                {
                    if (playerTurn)
                    {
                        Console.WriteLine($"Your turn! Choose attack:");
                        Console.WriteLine("1. Normal attack");
                        if (player is Mage mage)
                        {
                            Console.WriteLine("2. Heal (Costs 20 Mana)");
                            Console.WriteLine("3. Restrain enemy (Costs 90 Mana)");
                        }
                        else if (player is Archer archer)
                        {
                            Console.WriteLine("2. Multi shot");
                            Console.WriteLine("3. Life Drain arrow");
                        }
                        else if (player is Knight knight)
                        {
                            Console.WriteLine("2. Ground slam");
                            Console.WriteLine("3. Spinning slash");
                        }

                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                player.attack(enemy);
                                break;
                            case "2":
                                if (player is Mage mage2) mage2.heal();
                                else if (player is Archer archer2) archer2.MultiShot(enemy);
                                else if (player is Knight knight2) knight2.GroundSlam(enemy);
                                else Console.WriteLine("Invalid choice.");
                                break;
                            case "3":
                                if (player is Mage mage3) mage3.restrain(enemy);
                                else if (player is Archer archer3) archer3.LifeDrainArrow(enemy);
                                else if (player is Knight knight3) knight3.SpinningSlash(enemy);
                                else Console.WriteLine("Invalid choice.");
                                break;
                            default:
                                Console.WriteLine("Invalid choice, normal attack used.");
                                player.attack(enemy);
                                break;
                        }
                    }
                    else
                    {
                        if (enemy.IsRestrained)
                        {
                            Console.WriteLine($"{enemy.Name} is restrained and misses the turn.");
                            enemy.IsRestrained = false;
                        }
                        else
                        {
                            enemy.attack(player);
                        }
                    }

                    Console.WriteLine($"{player.Name} HP: {(player.Hp < 0 ? 0 : player.Hp)} | {enemy.Name} HP: {enemy.Hp}");

                    playerTurn = !playerTurn; 
                }

                if (player.Hp > 0)
                {
                    Console.WriteLine("You won this round!");
                    wins++;
                }
                else
                {
                    Console.WriteLine("You lost this round!");
                    break;
                }
            }

            Console.WriteLine($"Game Over! You won {wins} out of {totalRounds} rounds.");

            FileManager.SavePlayerStats(player, totalRounds, wins);

            string leaderboard = FileManager.GetLeaderboard();
            if (!string.IsNullOrEmpty(leaderboard))
            {
                Console.WriteLine("\nTop 10 Leaderboard (by total wins):");
                Console.WriteLine(leaderboard);
            }
            else
            {
                Console.WriteLine("\nNo leaderboard data available yet.");
            }

            Console.WriteLine("Game stats saved. Press any key to exit.");
            Console.ReadKey();
        }

        private static Player ChoosePlayerClass()
        {
            Console.WriteLine("Choose a class:");
            Console.WriteLine("1. Knight");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Archer");
            string choice = Console.ReadLine();
            Console.WriteLine("Enter your name:");
            string playerName = Console.ReadLine() ?? "Player";

            switch (choice)
            {
                case "1":
                    return new Knight(playerName, 200, 50, 20);
                case "2":
                    return new Mage(playerName, 150, 40, 10, 100);
                case "3":
                    return new Archer(playerName, 120, 40, 15);
                default:
                    Console.WriteLine("Invalid choice, defaulting to Knight.");
                    return new Knight(playerName, 200, 50, 20);
            }
        }
    }
}