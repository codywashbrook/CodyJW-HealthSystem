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
            Console.ReadKey(true);
            TakeDamage(80); //range checking
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(-15);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            Heal(75);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            Heal(-17);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            RegenerateShield(120);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            RegenerateShield(-79);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(120);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(30);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(15);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(35);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            Reset();
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(200);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            Reset();
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(200);
            Console.ReadKey(true);
            ShowHUD();



            Console.ReadKey(true);
        }
        static void Heal(int hp)
        {
            health = health + hp;
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine("Player is about to take " + damage + " damage..."); // debug: shows what line is playing
                                                                                   //shield = shield - damage;

            if (damage < 0)
            {
                health = health;
                shield = shield;
                
                Console.WriteLine("[ERROR: Negative Value]");
            }
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


        }

        static void ShowHUD()
        {

            string status;
            status = "";
            Console.WriteLine();

            if (health >= 75)
            {
                status = "Good";
            }

            if (health == 50)
            {
                status = "Fine";
            }
            
            if ((health <= 35) && (health >= 5)) // && and operator
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

            if ((shield == 0) && (health == 0) && lives == 0)
            {
                Console.WriteLine();
                Console.WriteLine("The Hero cannot be heard upon the macabre screams and pain, from the depths of The Underworld.... GAME OVER. ");
                System.Media.SystemSounds.Hand.Play();
                Console.WriteLine();
            }
        }

        static void Reset()
        {
            Console.WriteLine();
            if (lives == 2)
            {
                Console.WriteLine("The Gods Have Bestowed Upon You Another Chance..." + " RESET");
            }
            if (lives == 1)
            {
                Console.WriteLine("The Gods Grow Impatient... The Harsh Underworld Awaits if Defeated Once Again." + " RESET");
            }
            health = 100;
            shield = 100;
        }
    }
}