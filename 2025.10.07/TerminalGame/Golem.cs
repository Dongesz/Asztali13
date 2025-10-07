using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Golem : Enemy
    {
        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;

        public Golem(string name, int hp, int dp, int defense) : base(name, hp, dp, defense)
        {
            Name = "Golem";
            Hp = 250;
            Dp = 30;
            Defense = 25;

            _initialHp = Hp;
            _initialDp = Dp;
            _initialDefense = Defense;
        }

        public override void attack(Player player)
        {
            Console.WriteLine($"\n{Name} crushes the ground causing a shock!\n");
            base.attack(player);
            // defense-- Dp++
            Defense = Math.Max(0, Defense - 5);
            Dp += 5;
            Console.WriteLine($"\n{Name}'s Defense decreased to {Defense} and Damage increased to {Dp}\n");
        }
    }
}
