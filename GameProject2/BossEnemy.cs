using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameProject2
{
    internal class BossEnemy: Enemy
    {
        public BossEnemy(int health, int damage) : base(health, damage)
        {
     

    }
        public override void Attack(Player player)
        {
            // Implement boss's attack logic here
            base.Attack(player);
        }
    }
}
