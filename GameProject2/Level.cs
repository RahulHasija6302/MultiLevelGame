using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject2
{
    internal class Level
    {
        protected List<Enemy> enemies;
        private int levelNumber;

        public Level(List<Enemy> enemies)
        {
            this.levelNumber = levelNumber;
            this.enemies = enemies;
        }

        public void StartLevel(Player player)
        {
            Random rand = new Random();

            while (player.IsAlive() && enemies.Any(enemy => enemy.IsAlive()))
            {
                foreach (var enemy in enemies)
                {
                    if (!enemy.IsAlive())
                        continue;

                    // Player's turn
                    Console.WriteLine($"Player health: {player.GetHealth()}/{player.GetMaxHealth()}");
                    Console.WriteLine($"Enemy health: {enemy.GetHealth()}");
                    Console.WriteLine("Choose your action: 1 - Attack, 2 - Heal");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        // Introduce randomness for player's attack success
                        int playerAttackChance = rand.Next(1, 101); // Random number between 1 and 100
                        if (playerAttackChance <= 80) // 80% chance of successful attack
                        {
                            player.Attack(enemy);
                        }
                        else
                        {
                            Console.WriteLine("Your attack missed!");
                        }
                    }
                    else if (input == "2")
                    {
                        player.Heal();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again.");
                    }

                    // Check if enemy is defeated after player's turn
                    if (!enemy.IsAlive())
                    {
                        Console.WriteLine("Enemy is defeated!");
                        continue; // Skip enemy's turn if defeated
                    }

                    // Enemy's turn
                    int enemyAttackChance = rand.Next(1, 101); // Random number between 1 and 100
                    if (enemyAttackChance <= 80) // 80% chance of successful attack
                    {
                        enemy.Attack(player);
                    }
                    else
                    {
                        Console.WriteLine("Enemy's attack missed!");
                    }

                    // Check if player is defeated after enemy's turn
                    if (!player.IsAlive())
                    {
                        Console.WriteLine("Player is defeated!");
                        return;
                    }

                    switch (levelNumber)
                    {
                        case 1:
                            Console.WriteLine("You found a map!");
                            break;
                        case 2:
                            player.AddSpecialItem("Sword");
                            break;
                        case 3:
                            player.AddSpecialItem("Shield");
                            break;
                        case 4:
                            player.AddSpecialItem("Armour");
                            break;
                        case 5:
                            player.AddSpecialItem("Bow");
                            break;
                        case 6:
                            Console.WriteLine("Congratulations! You have reached the final level!");
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }
            }

            // Determine winner randomly
            if (rand.Next(1, 101) <= 50) // 50% chance of player winning
            {
                Console.WriteLine("Player Wins!");
            }
            else
            {
                Console.WriteLine("Enemy Wins!");
            }

        }

    }
}
