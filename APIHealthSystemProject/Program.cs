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
            shield = 100;
            lives = 3;
            experience = 0;
            level = 1;

            Heal(100);
            RegenShield(10);
            TakeDamage(600);
            LevelUp(400);
            Console.WriteLine();
            UI_Info();
            ShowHUD();

           
            Console.ReadKey(true);
        }

        static void ShowHUD()
        {
            if (health > 100)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("|OVER| Health: " + health);
                Console.WriteLine("Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine("==============================");
                Console.WriteLine();
            }
            else if (health <= 75 && health >= 25)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("Health: " + health + " |HURT|");
                Console.WriteLine("Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine("==============================");
                Console.WriteLine();
            }
            else if (health <= 25)
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("Health: " + health + " |DANGER|");
                Console.WriteLine("Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine("==============================");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("Health: " + health);
                Console.WriteLine("Shield: " + shield);
                Console.WriteLine("Level: " + level + "|EXP: " + experience);
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine("==============================");
                Console.WriteLine();
            }
        }


        static void RESET()
        {
            Console.WriteLine("All stats reset");
            health = 100;
            shield = 100;
            lives = 3;
        }
        static void Heal(int healup)
        {
            int currenthealth = health;
            if (healup > 0)
            {
                Console.WriteLine("DEBUG: About to heal for " + healup + "HP");
            }
            currenthealth = currenthealth + healup;
            if (currenthealth > 150)
            {
                health = 150;
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
        }

        static void RegenShield(int shieldrepair)
        {
            int currentshield = shield;
            if (shieldrepair > 0)
            {
                Console.WriteLine("DEBUG: About to repair " + shieldrepair + " SHIELD");
            }
            currentshield = currentshield + shieldrepair;
            if (currentshield > 100)
            {
                shield = 100;
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
        static void LevelUp(int currentEXP)
        {
            int expCap = 100;
            if (currentEXP > 0)
            {
                Console.WriteLine("DEBUG: About to gain " + currentEXP + " points of experience");
            }
          
            Console.WriteLine();
            
            while (currentEXP >= expCap)
            {
                level = level + 1;
                currentEXP = currentEXP - expCap;
                expCap = expCap + expCap;
                
            }
            experience = currentEXP;
            
        }
        static void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                Console.WriteLine("DEBUG: About to take " + damage + "damage");
            }
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
                Console.WriteLine("Player took too much damage. Player loses a life");
                lives = lives - 1;
                health = 100;
                shield = 100;
            }
            if (lives == 0)
            {
                Console.WriteLine("No lives left. Game Over");
            }
            
        }
        static void UI_Info()
        {
            if (health > 150)
            {
                Console.WriteLine("Max |OVERHEAL|");
            }
            if (shield > 100)
            {
                Console.WriteLine("|FULL| Shield");
            }
            if (experience > 0)
            {
                Console.WriteLine("You have " + experience + " EXP");
            }
            if (level + 1 > level)
            {
                Console.WriteLine("You LEVELED up");
            }
        }
    }
}
