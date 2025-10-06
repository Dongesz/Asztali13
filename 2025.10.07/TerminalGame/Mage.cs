using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalGame
{
    internal class Mage : Player
    {
        public int Mana { get; set; }
        private readonly int _initialMana;
        private readonly int _initialHp;
        private readonly int _initialDp;
        private readonly int _initialDefense;

        public Mage(string name, int hp, int dp, int defense, int mana) : base(name, hp, dp, defense)
        {
            Name = "Mage";
            Hp = 150;
            Dp = 40;
            Defense = 10;
            Mana = 100;
            MaxHp = 150;

            _initialHp = Hp;
            _initialDp = Dp;
            _initialDefense = Defense;
            _initialMana = Mana;
        }

        public override void resetStats()
        {
            base.resetStats();
            Mana = _initialMana;
        }

        public override void attack(Enemy enemy)
        {
            if (Mana >= 30)
            {
                Console.WriteLine($"{Name} casts a powerful spell!");
                enemy.Hp -= Dp * 2;
                Mana -= 30;
                Console.WriteLine($"{Name}'s Mana: {Mana}");
            }
            else
            {
                Console.WriteLine($"{Name} uses a basic attack due to low Mana.");
                enemy.Hp -= Dp;
            }
        }
        public void heal()
        {
            if (Mana >= 20)
            {
                Console.WriteLine($"{Name} heals self!");
                Hp = Math.Min(Hp + 50, MaxHp);
                Mana -= 20;
                Console.WriteLine($"{Name}'s Mana: {Mana}");
                Console.WriteLine($"{Name}'s HP after healing: {Hp}/{MaxHp}");
            }
            else
            {
                Console.WriteLine($"{Name} tried to heal but has insufficient mana.");
            }
        }
        public void restrain(Enemy enemy)
        {
            if (Mana >= 90)
            {
                Console.WriteLine($"{Name} restrains the enemy, preventing their next attack!");
                Mana -= 90;
                enemy.IsRestrained = true;
                Console.WriteLine($"{Name}'s Mana: {Mana}");
            }
            else
            {
                Console.WriteLine($"{Name} tried to restrain but has insufficient mana.");
            }
        }
    }
}
