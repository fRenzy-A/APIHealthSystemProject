using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHealthSystemProject
{
    internal class Program
    {
        static string healthOVER;
        static string healthStatues;
        static int health;
        static int shield;
        static int lives;
        static int experience;
        static int level;
        static void Main(string[] args)
        {
            health = 100;
            shield = 100;
            lives = 3;
            experience = 0;
            level = 1;

            ShowHUD();
            Heal(30);
            ShowHUD();

            RESET();
            ShowHUD();
            TakeDamage(140);
            ShowHUD();

            RESET();
            ShowHUD();
            RegenShield(5);
            ShowHUD();

            RESET();
            ShowHUD();
            LevelUp(400);
            ShowHUD();

            RESET();
            ShowHUD();
            TakeDamage(230);
            ShowHUD();

            RESET();
            ShowHUD();
            Heal(-30);
            TakeDamage(-100);
            ShowHUD();
           
            Console.ReadKey(true);
        }

        static void UpdateHealthStatus()
        {
            if (health > 100)
            {
                healthOVER = "|OVER| ";
            }
            else if (health <= 75 && health >= 25)
            {
                healthStatues = "|HURT|";
            }
            else if (health <= 25)
            {
                healthStatues = "|DANGER|";
            }
            else
            {
                
            }
        }

        static void ShowHUD()
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine(healthOVER + "Health: " + health + " " + healthStatues);
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Level: " + level + "|EXP: " + experience);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("==============================");
            Console.WriteLine();
        }


        static void RESET() // Resets all stats to default when called
        {
            Console.WriteLine("Game reset");
            Console.WriteLine();
            health = 100;
            shield = 100;
            lives = 3;
            experience = 0;
            level = 1;
            healthStatues = "";
            healthOVER = "";
            UpdateHealthStatus();
        }

        static void Heal(int healup) // Heal method
        {
            int currenthealth = health;
            if (healup > 0)
            {
                Console.WriteLine("DEBUG: About to heal for " + healup + "HP");
                Console.WriteLine();
            }
            currenthealth = currenthealth + healup;
            if (currenthealth > 150)
            {
                currenthealth = 150;
                health = currenthealth;
                Console.WriteLine("Max |OVERHEAL|");
            }
            else if (healup < 0)
            {
                Console.WriteLine("About to heal for " + healup + " HP");
                Console.WriteLine("ERROR: Cannot have a negative health integer value");
            }
            else
            {
                health = currenthealth;
            }

            UpdateHealthStatus();
        }

        static void RegenShield(int shieldrepair) // Shield method
        {
            int currentshield = shield;
            if (shieldrepair > 0)
            {
                Console.WriteLine("DEBUG: About to repair " + shieldrepair + " SHIELD");
                Console.WriteLine();
            }
            currentshield = currentshield + shieldrepair;
            if (currentshield > 100)
            {
                currentshield = 100;
                shield = currentshield;
                Console.WriteLine("|FULL| Shield");
            }
            if (shieldrepair < 0)
            {
                Console.WriteLine("About to repair " + shieldrepair + "SHIELD");
                Console.WriteLine("ERROR: Cannot have a negative shield integer value");
            }
            else
            {
                shield = currentshield;
            }
        }
        static void LevelUp(int currentEXP) // EXP method
        {
            int expCap = 100;
            if (currentEXP > 0)
            {
                Console.WriteLine("DEBUG: About to gain " + currentEXP + " points of experience");
                Console.WriteLine();
            }
          
            Console.WriteLine();
            
            while (currentEXP >= expCap)
            {
                level = level + 1;
                currentEXP = currentEXP - expCap;
                expCap = expCap + expCap;
                Console.WriteLine("LEVEL UP");
            }
            experience = currentEXP;
            
        }
        static void TakeDamage(int damage) // Damage method
        {
            if (damage > 0)
            {
                Console.WriteLine("DEBUG: About to take " + damage + "damage");
            }
            if (damage < 0)
            {
                Console.WriteLine("DEBUG: About to take " + damage + " damage");
                Console.WriteLine("ERROR: Cannot have a negative damage integer value");
            }
            else if (shield < damage) // Spillover
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
                Console.WriteLine("Player took too much damage. Player loses a life");
                lives = lives - 1;
                health = 100;
                shield = 100;
                experience = 0;
                healthStatues = "";
            }
            if (lives == 0)
            {
                Console.WriteLine("No lives left. Game Over");
            }

            UpdateHealthStatus();
        }
    }
}
