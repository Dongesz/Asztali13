using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Zombie : Enemy
    {
        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;

        public Zombie(string name, int hp, int dp, int defense) : base(name, hp, dp, defense)
        {
            Name = "Zombie";
            Hp = 120;
            Dp = 20;
            Defense = 10;

            _initialHp = Hp;
            _initialDp = Dp;
            _initialDefense = Defense;
        }

        public override void attack(Player player)
        {
            Console.WriteLine($"\n{Name} bites fiercely!\n");
            base.attack(player);
            // 10% 
            Random rnd = new Random();
            if (rnd.Next(0, 100) < 10)
            {
                int healAmount = 10;
                Hp += healAmount;
                
                Console.WriteLine($"\n{Name} regenerates {healAmount} HP!\n");
            }
        }
    }
}
