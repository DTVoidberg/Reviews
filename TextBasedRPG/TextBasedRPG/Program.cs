using System.Numerics;
using System;
using System.Net.Http.Headers;
using System.Xml;

namespace TextBasedRPG;


public class RPG
{

    public static void Main(string[] args)
    {


        List<Unit> enemies = [];

        Unit player = new Unit(100, 100, 20, 20, 20, 15, "Player");
        Unit enemy1 = new Unit(75, 0, 10, 5, 10, 12, "Dark Mage");
        Unit enemy2 = new Unit(150, 0, 35, 5, 12, 5, "Orc");
        Random random = new Random();

        enemies.Add(enemy1);
        enemies.Add(enemy2);


        int isRandom = random.Next(0, 2);

        Console.WriteLine("Welcome to this Text Based RPG!\nLet's Start!\n");

        {


            while (!player.IsDead && enemies.Any(e => !e.IsDead))
            {
                var enemy = enemies.First(e => !e.IsDead);
                Console.WriteLine($"\n{player.UnitName}\nHP = {player.HP}.\nMana = {player.Mana}\n\n{enemy.UnitName} HP = {enemy.HP}\n");
                Console.WriteLine("Player's turn, What will you do?\nPress A to Attack,S to cast Fireball or Press D to Heal\n");
                var choice = Console.ReadLine();

                //var result = choice == "a" ? player.Attack(enemy1) : choice == "d" ? player.Heal : player.UserInput;
                if (choice == "a")
                {
                    player.Attack(enemy);
                }
                else if (choice == "d")
                {
                    player.Heal();
                }
                else if (choice == "s")
                {
                    player.FireBall(enemy);
                }
                else
                {
                    Console.WriteLine("Please enter a valid input!.");
                }
                if (player.IsDead && !enemy.IsDead)
                {
                    break;
                }

                Console.WriteLine($"{player.UnitName} HP = {player.HP}. {enemy.UnitName} HP = {enemy.HP}");

                Console.WriteLine("\nEnemies Turn!");

                if (isRandom == 0)
                {
                    enemy.Attack(player);
                }
                else
                {
                    enemy.Heal();
                }

            }
        }
    }
}