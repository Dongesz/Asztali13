using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Player
    {
        private string Name { get; set; }
        public int Hp { get; set; }
        private int Dp { get; set; }
        private int Defense { get; set; }

        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;

        public Player(string name, int hp, int dp, int defense)
        {
            Name = name;
            Hp = hp;
            Dp = dp;
            Defense = defense;

            _initialHp = hp;
            _initialDp = dp;
            _initialDefense = defense;
        }

        public void takeDamage(int Dp)
        {
            this.Hp -= Dp;
        }

        public void attack(Enemy enemy)
        {
            enemy.Hp -= Dp;
        }

        public void resetStats()
        {
            Hp = _initialHp;
            Dp = _initialDp;
            Defense = _initialDefense;
        }
    }
}
