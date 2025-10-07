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
                Console.WriteLine($"\n{Name} casts a powerful spell!\n");
                enemy.Hp -= Dp * 2;
                Mana -= 30;
                Console.WriteLine($"\n{Name}'s Mana: {Mana}\n");
            }
            else
            {
                Console.WriteLine($"\n{Name} uses a basic attack due to low Mana.\n");
                enemy.Hp -= Dp;
            }
        }
        public void heal()
        {
            if (Mana >= 20)
            {
                Console.WriteLine($"\n{Name} heals self!\n");
                Hp = Math.Min(Hp + 50, MaxHp);
                Mana -= 20;
                Console.WriteLine($"\n{Name}'s Mana: {Mana}\n");
                Console.WriteLine($"\n{Name}'s HP after healing: {Hp}/{MaxHp}\n");
            }
            else
            {
                Console.WriteLine($"\n{Name} tried to heal but has insufficient mana.\n");
            }
        }
        public void restrain(Enemy enemy)
        {
            if (Mana >= 90)
            {
                Console.WriteLine($"\n{Name} restrains the enemy, preventing their next attack!\n");
                Mana -= 90;
                enemy.IsRestrained = true;
                Console.WriteLine($"\n{Name}'s Mana: {Mana}\n");
            }
            else
            {
                Console.WriteLine($"\n{Name} tried to restrain but has insufficient mana.\n");
            }
        }
    }
}
