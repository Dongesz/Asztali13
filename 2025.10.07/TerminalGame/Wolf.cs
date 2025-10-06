using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Wolf : Enemy
    {
        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;
        private int SpecialAttackCount = 0;

        public Wolf(string name, int hp, int dp, int defense) : base(name, hp, dp, defense)
        {
            Name = "Wolf";
            Hp = 130;
            Dp = 25;
            Defense = 8;

            _initialHp = Hp;
            _initialDp = Dp;
            _initialDefense = Defense;
        }

        public override void attack(Player player)
        {
            Console.WriteLine($"{Name} lunges at the player!");
            base.attack(player);
            SpecialAttackCount++;
            if (SpecialAttackCount % 3 == 0)
            {
                Console.WriteLine($"{Name} uses a ferocious double attack!");
                player.Hp -= Dp;
            }
        }
    }
}
