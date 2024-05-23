using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        private int userStrength;
        private int userDexterity;
        private int userIntelligence;
        private int userLuck;
        private int userArmor;
        private string unitName;
        private Random random;

        public int HP { get { return unitCurrentHP; } }
        public string UnitName { get { return unitName; } }
        public bool IsDead { get { return unitCurrentHP <= 0;} }
        public int Mana { get { return unitCurrentMana; } }


        public Unit(int unitMaxHP, int unitMaxMana, int userStrength, int userDexterity, int attackPower, int healPower, string unitName)
        {
            this.unitMaxHP = unitMaxHP;
            this.unitMaxMana = unitMaxMana;
            this.unitCurrentMana = unitMaxMana;
            this.unitCurrentHP = unitMaxHP;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.userStrength = userStrength;
            this.userDexterity = userDexterity;
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
        public void FireBall(Unit unitToAttack)
        {

            if (unitCurrentMana >= 25)
            {
                double rng = random.NextDouble();
                rng = rng / 2 + 1.25f;
                int randomDamage = (int)(attackPower * rng);
                unitToAttack.TakeDamage(randomDamage);
                Console.WriteLine($"{unitName} casts Fireball at {unitToAttack.unitName} and deals {randomDamage} damage!");
                unitCurrentMana = int.Clamp(unitCurrentMana - 25, 0, unitMaxMana);
                Console.WriteLine("Fireball cost you 25 mana.");
            }
            else
            {
                Console.WriteLine("You do not have the mana for this action.");
            }
        }

        public void TakeDamage(int damage)

        {
            bool isBlocking = random.Next(1, 101) < 5;
            bool isDodging = random.Next(1, 101) < 5;
           

            if (isBlocking)
            {
                damage = damage - damage * (userStrength / 100);
                Console.WriteLine("\nYou managed to block some damage!\n");
            }
            if (isDodging) 
            {
                damage = damage - damage * (userDexterity / 100);
                Console.WriteLine("\nYou managed to dodge some damage!\n");
            }

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
        public void ManaRegen() 
        { 

        }
    }
}
