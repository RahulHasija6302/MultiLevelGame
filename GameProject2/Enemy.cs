using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject2
{
    internal class Enemy
    {
        protected int health;
        protected int damage;

        public Enemy(int health, int damage)
        {
            this.health = health;
            this.damage = damage;
        }

        public virtual void Attack(Player player)
        {
            if (player == null)
            {
                Console.WriteLine("No player to attack!");
                return;
            }

            Random rand = new Random();
            int damage = rand.Next(this.damage / 2, this.damage + 1);
            player.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            Console.WriteLine($"Enemy took {damage} damage!");
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public int GetHealth()
        {
            return health;
        }
    }
}
