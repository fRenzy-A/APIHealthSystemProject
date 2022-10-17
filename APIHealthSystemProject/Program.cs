using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHealthSystemProject
{
    internal class Program
    {
        static int health;
        static int shield;
        static int lives;
        static int experience;
        static int level;
        static void Main(string[] args)
        {
            health = 100;
            shield = 50;
            lives = 3;
            experience = 0;
            level = 1;

            TakeDamage(0);
            Heal(30);
            RegenShield(-40);
            ShowHUD();

            RESET();
            ShowHUD();
            Console.ReadKey(true);
        }

        static void ShowHUD()
        {
            
            if (health > 100 && shield > 50)
            {
                Console.WriteLine();
                Console.WriteLine("|OVER| Health: " + health);
                Console.WriteLine("|FULL| Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine();
            }
            else if (health > 100)
            {
                Console.WriteLine();
                Console.WriteLine("|OVER| Health: " + health);
                Console.WriteLine("Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine();
            }

            else if (shield > 50)
            {
                Console.WriteLine();
                Console.WriteLine("Health: " + health);
                Console.WriteLine("|FULL| Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("Health: " + health);
                Console.WriteLine("Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine();
            }
        }

        static void TakeDamage(int damage)
        {
            if (shield < damage)
            {
                health = (health + shield) - damage;
                shield = 0;
            }
            else if (shield == 0)
            {
                health = health - damage;
            }
            else
            {
                shield = shield - damage;
            }
            if (health <= 0)
            {
                lives = lives - 1;
                Console.WriteLine("Player took too much damage. Player loses a life");
            }
            if (lives == 0)
            {
                Console.WriteLine("No lives left. Game Over");
            }
            
        }

        static void RESET()
        {
            health = 100;
            shield = 50;
            lives = 3;
        }
        static void Heal(int healup)
        {
            int currenthealth = health;
            currenthealth = currenthealth + healup;
            if (healup < 0)
            {
                Console.WriteLine("ERROR: Cannot have a negative health integer value");
            }
            else if (currenthealth >= 150)
            {
                health = 150;
                Console.WriteLine("Max |OVERHEAL|");
            }
            else
            {
                health = currenthealth;
            }
        }

        static void RegenShield(int shieldrepair)
        {
            int currentshield = shield;
            currentshield = currentshield + shieldrepair;
            if (shieldrepair < 0)
            {
                Console.WriteLine("ERROR: Cannot have a negative shield integer value");
            }
            else if (currentshield > 50)
            {
                shield = 50;
                Console.WriteLine("|FULL| Shield");
            }
            else
            {
                shield = currentshield;
            }
        }

        static void LevelUp()
        {

        }
    }
}
