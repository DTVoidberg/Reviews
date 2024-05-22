using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Unit
    {
        private int unitMaxHP;
        private int unitCurrentHP;
        private int unitCurrentMana;
        private int unitMaxMana;
        private int healPower;
        private int attackPower;
        private int userStrengh;
        private int userDexterity;
        private int userIntelligence;
        private int userArmor;
        private string unitName;
        private Random random;

        public int HP { get { return unitCurrentHP; } }
        public string UnitName { get { return unitName; } }
        public bool IsDead { get { return unitCurrentHP <= 0;} }



        public Unit(int unitMaxHP, int attackPower, int healPower, string unitName)
        {
            this.unitMaxHP = unitMaxHP;
            this.unitCurrentHP = unitMaxHP;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random();
        }
        public void Attack(Unit unitToAttack)
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int randomDamage = (int)(attackPower * rng);
            unitToAttack.TakeDamage(randomDamage);
            Console.WriteLine($"{unitName} attack {unitToAttack.unitName} and deals {randomDamage} damage!");
        }
        public void TakeDamage(int damage)
        {
            unitCurrentHP -= damage;

            if (IsDead)
            {
                Console.WriteLine($"{UnitName} has been slain!.");
                
            }

        }
        public void Heal()
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int heal = (int)(rng * healPower);
            unitCurrentHP = heal + unitCurrentHP > unitMaxHP ? unitMaxHP : unitCurrentHP + heal;
            Console.WriteLine($"{UnitName}heals {heal}HP");
        }
        public void Armor()
        {

        }
    }
}
