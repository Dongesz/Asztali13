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
            Hp = 200;
            Dp = 50;
            Defense = 20;
            MaxHp = 200;

            _initialHp = Hp;
            _initialDp = Dp;
            _initialDefense = Defense;
        }

        public override void resetStats()
        {
            Hp = _initialHp;
            Dp = _initialDp;
            Defense = _initialDefense;
            Console.WriteLine($"\n{Name} ({GetType().Name}) stats have been reset: HP={Hp}, DP={Dp}, Defense={Defense}\n");
        }

        public override void takeDamage(int Dp)
        {
            int damageTaken = Math.Max(1, Dp - Defense);
            Hp -= damageTaken;
            Console.WriteLine($"\n{Name} ({GetType().Name}) defends and takes {damageTaken} damage (Enemy DP: {Dp}, Defense: {Defense})\n");
            Console.WriteLine($"\n{Name}'s current HP: {Hp}\n");
        }

        // Heavy attack
        public override void attack(Enemy enemy)
        {
            int damage = Dp * 3;
            enemy.Hp -= damage;
            Console.WriteLine($"\n{Name} ({GetType().Name}) performs a HEAVY ATTACK!\n");
            Console.WriteLine($"\n{enemy.Name} took {damage} damage! (Current HP: {enemy.Hp})\n");
        }
        public void SpinningSlash(Enemy enemy)
        {
            int damage = Dp * 2;
            enemy.Hp -= damage;
            Console.WriteLine($"\n{Name} ({GetType().Name}) performs a SPINNING SLASH!\n");
            Console.WriteLine($"\n{enemy.Name} took {damage} damage! (Current HP: {enemy.Hp})\n");
        }
        public void GroundSlam(Enemy enemy)
        {
            int damage = Dp * 4;
            enemy.Hp -= damage;
            Console.WriteLine($"\n{Name} ({GetType().Name}) performs a GROUND SLAM!\n");
            Console.WriteLine($"\n{enemy.Name} took {damage} damage! (Current HP: {enemy.Hp})\n");
        }
    }
}
