using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Enemy
    {
        public string Name { get; set; }
        public int Hp{ get; set; }
        public int Dp{ get; set; }
        public int Defense { get; set; }
        public bool IsRestrained { get; set; }

        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;

        public Enemy(string name, int hp, int dp, int defense)
        {
            Name = name;
            Hp = hp; 
            Dp = dp; 
            Defense = defense;
            IsRestrained = false;

            _initialHp = hp;
            _initialDp = dp;
            _initialDefense = defense;
        }
        
        virtual public void takeDamage(int Dp)
        {
            this.Hp -= Dp;
        }

        virtual public void attack(Player player)
        {
            player.Hp -= Dp;
        }

        virtual public void resetStats()
        {
            Hp = _initialHp;
            Dp = _initialDp;
            Defense = _initialDefense;
            IsRestrained = false;
        }

    }
}
