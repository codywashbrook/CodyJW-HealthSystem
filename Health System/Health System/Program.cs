using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_System
{
    internal class Program
    {
        static int health;
        static int shield;
        static int lives;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Health System");
            Console.ResetColor();
            Console.WriteLine();


            health = 100;
            shield = 100;
            lives = 003;

            ShowHUD();
            TakeDamage(100); //range checking
            ShowHUD();
            TakeDamage(10);
            ShowHUD();
            Heal(-20);
            ShowHUD();


            Console.ReadKey(true);
        }
        static void Heal(int hp)
        {
            health = health + hp;
            Console.WriteLine("Player has healed by: " + hp + " points...");

            if (hp > 100)
            {
                health = 100;
                Console.WriteLine("[Player is at Max HP and Cannot Heal Anymore]");
            }
            if (hp < 0)
            {
                health = health - hp;
                Console.WriteLine("[ERROR: Negative Value]");
                Console.WriteLine();

            }
            if (health < 0)
            {
                health = 0;
            }
            if (health > 100)
            {
                health = 100;
                Console.WriteLine("[Player is at Max HP and Cannot Heal Anymore]");
            }
        }
        static void RegenerateShield(int regen)
        {
            shield = shield + regen;
            Console.WriteLine("Player has picked up a shield: " + regen + " points regenerated...");
            if (regen > 100)
            {
                shield = 100;
                Console.WriteLine("[Player is at Max Shield and Cannot Regenerate Anymore]");
            }
            if (regen < 0)
            {
                shield = shield - regen;
                Console.WriteLine("[ERROR: Negative Value]");
                Console.WriteLine();
            }
            if (shield < 0)
            {
                shield = 0;
            }
            if (shield > 100)
            {
                shield = 100;
                Console.WriteLine("[Player is at Max Shield and Cannot Regenerate Anymore]");
            }
        }
        static void TakeDamage(int damage) //damage only works w int
        {
            Console.WriteLine("Player is about to take " + damage + " damage..."); // debug: shows what line is playing
            //shield = shield - damage;
            if (shield == 100)
            {
                health = health + shield - damage;
                shield = shield - damage;
            }
            else if (shield == 0)
            {
                health = health - damage;
            }
            if (shield > 100)
            {
                shield = 100;
            }
            if (shield < 0)
            {
                shield = 0;
            }
            if (health < 0)
            {
                health = 0;
            }
            if (health > 100)
            {
                health = 100;
            }
            if (damage < 0)
            {
                shield = shield;
                health = health;
                Console.WriteLine("[ERROR: Negative Value]");
            }

        }

        static void ShowHUD()
        {

            string status;
            status = "";
            Console.WriteLine();

            if (shield >= 75)
            {
                status = "Great";
            }

            if ((shield <= 50) && (shield >= 30))
            {
                status = "Good";
            }

            if (health >= 75)
            {
                status = "Fine";
            }

            if ((health <= 50) && (health >= 30)) // && and operator
            {
                status = "HURT";
            }

            if ((health == 0) && (shield == 0))
            {
                status = "Dead";
                lives = lives - 1;
            }

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Health status: " + status);
            Console.ResetColor();

            if ((shield == 0) && (health == 0) && lives == 0)
            {
                Console.WriteLine("Game Over");
            }
            Console.BackgroundColor = ConsoleColor.Blue ;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Shield: " + shield);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Lives: 00" + lives);
            Console.ResetColor();
        }

        static void Reset()
        {
            Console.WriteLine("RESET");
            health = 100;
            shield = 100;
        }
    }
}