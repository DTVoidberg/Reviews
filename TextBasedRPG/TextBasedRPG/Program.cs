using System.Numerics;
using System;
using System.Net.Http.Headers;
using System.Xml;

namespace TextBasedRPG;


public class RPG
{

    public static void Main(string[] args)
    {
        Unit player = new Unit(100, 20, 15, "Player");
        Unit enemy1 = new Unit(75, 10, 12, "Dark Mage");
        Unit enemy2 = new Unit(150, 12, 5, "Orc");
        Random random = new Random();

        int rand = random.Next(0, 2);

        Console.WriteLine("Welcome to this Text Based RPG!\nLet's Start!");

        {


            while (!player.IsDead && !enemy1.IsDead)
            {

                Console.WriteLine($"{player.UnitName} HP = {player.HP}.\n{enemy1.UnitName} HP = {enemy1.HP}");
                Console.WriteLine("Player's turn, What will you do?\nPress A to Attack or Press D to Heal");
                var choice = Console.ReadLine();

                //var result = choice == "a" ? player.Attack(enemy1) : choice == "d" ? player.Heal : player.UserInput;
                if (choice == "a")
                {
                    player.Attack(enemy1);
                }
                else if (choice == "d")
                {
                    player.Heal();
                }
                else
                {
                    Console.WriteLine("Please enter a valid input!.");
                }
                if (player.IsDead && !enemy1.IsDead)
                {
                    break;
                }

                Console.WriteLine($"{player.UnitName} HP = {player.HP}. {enemy1.UnitName} HP = {enemy1.HP}");

                Console.WriteLine("Enemies Turn!");

                if (rand == 0)
                {
                    enemy1.Attack(player);
                }
                else
                {
                    enemy1.Heal();
                }
                //Hello

                while (!player.IsDead && !enemy2.IsDead && enemy1.IsDead)
                {
                    Console.WriteLine($"{player.UnitName} HP = {player.HP}.\n{enemy2.UnitName} HP = {enemy2.HP}");
                    Console.WriteLine("Player's turn, What will you do?\nPress A to Attack or Press D to Heal");
                    var choice2 = Console.ReadLine();

                    if (choice2 == "a")
                    {
                        player.Attack(enemy2);
                    }
                    else if (choice2 == "d")
                    {
                        player.Heal();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input!.");
                    }
                    if (player.IsDead && !enemy2.IsDead)
                    {
                        break;
                    }

                    Console.WriteLine($"{player.UnitName} HP = {player.HP}. {enemy2.UnitName} HP = {enemy2.HP}");

                    Console.WriteLine("Enemies Turn!");

                    if (rand == 0)
                    {
                        enemy2.Attack(player);
                    }
                    else
                    {
                        enemy2.Heal();
                    }

                    if (!player.IsDead && enemy2.IsDead)
                    {
                        break;
                    }
                }
            }

        }
    }
}