using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject2
{
    internal class Game
    {
        private Player player;
        private List<Level> levels;
        private int currentLevel;

        public Game()
        {
            player = new Player(100, 10, 20, 5); // Example starting stats
            levels = new List<Level>();
            InitializeLevels();
            currentLevel = 0;
        }

        private void InitializeLevels()
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                List<Enemy> enemies = new List<Enemy>();
                int numEnemies = i + 1;
                for (int j = 0; j < numEnemies; j++)
                {
                    // Initialize enemy health to 100
                    int enemyHealth = 100;
                    int enemyDamage = rand.Next(10, 21); // Random damage between 10 and 20
                    enemies.Add(new Enemy(enemyHealth, enemyDamage));
                }
                levels.Add(new Level(enemies));
                // Add boss fight for level 6
                List<Enemy> bossEnemies = new List<Enemy> { new BossEnemy(150, 25) }; // Adjust boss health and damage as needed
                levels.Add(new Level(bossEnemies));
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the Game!");
            while (currentLevel < levels.Count && player.IsAlive())
            {
                Console.WriteLine($"Starting Level {currentLevel + 1}");
                Level level = levels[currentLevel];
                level.StartLevel(player);
                currentLevel++;
            }

            if (player.IsAlive())
            {
                Console.WriteLine("Congratulations! You've completed the game!");
            }
            else
            {
                Console.WriteLine("Game Over!");
            }
        }

    }
}
