using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLevelGame
{
    internal class Player
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int MeleeDamage { get; set; }
        public int RangedDamage { get; set; }
        public int Defence { get; set; }
        public List<string> SpecialAbilities { get; } = new List<string>();
        public List<string> Inventory { get; } = new List<string>();

        public Player()
        {
            // Initialize player stats
            MaxHealth = 100;
            Health = MaxHealth;
            MeleeDamage = 10;
            RangedDamage = 5;
            Defence = 5;
        }

        public void LevelUp()
        {
            // Increase stats after each level
            MaxHealth += 20;
            Health = MaxHealth;
            MeleeDamage += 2;
            Defence += 1;
        }

        public void Heal()
        {
            // Option for healing during battle
            Health = Math.Min(Health + 20, MaxHealth);
        }

        public virtual void Attack(Enemy enemy)
        {
            // Perform an attack
            int damage = new Random().Next(MeleeDamage / 2, MeleeDamage);
            enemy.TakeDamage(damage);
        }

        public string UseSpecialAbility()
        {
            // Trigger special abilities during attacks
            // Implement based on probability
            // Example: return "Critical Hits" or null
            // ...
            return null;
        }
    }
}
