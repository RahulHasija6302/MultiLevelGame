using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject2
{
    internal class Player
    {
        protected int health;
        protected int maxHealth;
        protected int meleeDamage;
        protected int rangedDamage;
        protected int defence;
        protected bool isBlocked;
        protected List<SpecialItem> specialItems;

        public Player(int maxHealth, int meleeDamage, int rangedDamage, int defence)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.meleeDamage = meleeDamage;
            this.rangedDamage = rangedDamage;
            this.defence = defence;
            this.isBlocked = false;
            specialItems = new List<SpecialItem>();
        }
        // Method to add a special item to the player's inventory
        public void AddSpecialItem(string itemName)
        {
            if (itemName != null)
            {
                specialItems.Add(new SpecialItem(itemName));
                Console.WriteLine($"Special Item Awarded - {itemName}");
            }

        }

        // Method to check if the player has a specific special item
        public bool HasSpecialItem(string itemName)
        {
            return specialItems.Exists(item => item.Name == itemName);
        }

        // Method to remove a special item from the player's inventory
        public void RemoveSpecialItem(string itemName)
        {
            SpecialItem itemToRemove = specialItems.Find(item => item.Name == itemName);
            if (itemToRemove != null)
            {
                specialItems.Remove(itemToRemove);
                Console.WriteLine($"Special Item Removed - {itemName}");
            }
        }
        public void Attack(Enemy enemy)
        {
            if (isBlocked)
            {
                Console.WriteLine("You blocked the attack!");
                isBlocked = false;
                return;
            }

            Random rand = new Random();
            int damage = rand.Next(meleeDamage / 2, meleeDamage + 1);
            enemy.TakeDamage(damage);
        }

        public void Heal()
        {
            health += 20; // Healing for a fixed amount
            if (health > maxHealth)
                health = maxHealth;
        }

        public virtual void LevelUp()
        {
            maxHealth += 10;
            health = maxHealth;
            meleeDamage += 5;
            defence += 2;
        }

        public void Block()
        {
            isBlocked = true;
        }

        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(damage - defence, 0);
            health -= actualDamage;
            Console.WriteLine($"You took {actualDamage} damage!");
        }



        public bool IsAlive()
        {
            return health > 0;
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public int GetMeleeDamage()
        {
            return meleeDamage;
        }

        public int GetRangedDamage()
        {
            return rangedDamage;
        }

        public int GetDefence()
        {
            return defence;
        }


    }

}
