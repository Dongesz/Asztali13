using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Archer : Player
    {
        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;

        public Archer(string name, int hp, int dp, int defense) : base(name, hp, dp, defense)
        {
            Name = "Archer";
            Hp = 120;
            Dp = 40;
            Defense = 15;
            MaxHp = 120;

            _initialHp = Hp;
            _initialDp = Dp;
            _initialDefense = Defense;
        }

        public override void attack(Enemy enemy)
        {
            Console.WriteLine($"{Name} shoots 4 arrows!");
            for (int i = 0; i < 4; i++)
            {
                enemy.Hp -= Dp;
            }
        }
    }
}
