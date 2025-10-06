using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Knight : Player
    {
        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;

        public Knight(string name, int hp, int dp, int defense) : base(name, hp, dp, defense)
        {
            Name = "Knight";
            Hp = 200;
            Dp = 50;
            Defense = 20;

            _initialHp = Hp;
            _initialDp = Dp;
            _initialDefense = Defense;
        }

        public override void resetStats()
        {
            Hp = _initialHp;
            Dp = _initialDp;
            Defense = _initialDefense;
            Console.WriteLine($"{Name} ({GetType().Name}) stats have been reset: HP={Hp}, DP={Dp}, Defense={Defense}");
        }

        // Heavy attack
        public override void attack(Enemy enemy)
        {
            int damage = Dp * 3;
            enemy.Hp -= damage;
            Console.WriteLine($"{Name} ({GetType().Name}) performs a HEAVY ATTACK!");
            Console.WriteLine($"{enemy.Name} took {damage} damage! (Current HP: {enemy.Hp})");
        }

        public override void takeDamage(int Dp)
        {
            int damageTaken = Math.Max(1, Dp - Defense);
            Hp -= damageTaken;
            Console.WriteLine($"{Name} ({GetType().Name}) defends and takes {damageTaken} damage (Enemy DP: {Dp}, Defense: {Defense})");
            Console.WriteLine($"{Name}'s current HP: {Hp}");
        }
    }
}
