using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLevelGame
{
    public abstract class Character
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Damage { get; }

        protected Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public abstract void Attack(Character target);
    }
}
