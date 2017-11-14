using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GadeAssignment1
{
    class ResourceBuilding : Building
    {

        protected string resourceType = "Coins";
        protected int resourcesPerTick = 5;
        protected const int resourcesRemaining = 100;
        protected string resourceSymbol = "#";

        // Constructor
        public ResourceBuilding(int x, int y, int health, int speed, bool attack, int attackRange, string faction, string symbol)
            : base(x, y, health, speed, attack, attackRange, faction, symbol)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.faction = faction;
            this.symbol = symbol;
        }

        public override bool isAlive()
        {
            if (this.health <= 0)
                return false;
            else
                return true;

        }
        public override string toString()
        {
            string output = "x : " + X + Environment.NewLine
                + "y : " + Y + Environment.NewLine
                + "Health: " + health + Environment.NewLine
                + "Speed: " + speed + Environment.NewLine
                + "Attack: " + (attack ? "Yes" : "No") + Environment.NewLine
                + "Attack Range: " + attackRange + Environment.NewLine
                + "Faction/Team: " + faction + Environment.NewLine;
            return output;
        }

        public override void save()
        {
            string page = @"File/save.txt";
            if (!File.Exists(page))
            {
                using (StreamWriter rf = File.CreateText(page))
                {
                    rf.WriteLine(x);
                    rf.WriteLine(y);
                    rf.WriteLine(health);
                    rf.WriteLine(faction);
                    rf.WriteLine(symbol);

                }
            }
        }
        public override void read()
        {
            string fileName = @"File/save.txt";

            if (File.Exists(fileName))
            {
                using (StreamWriter rf = File.CreateText(fileName))
                    rf.WriteLine(fileName);
            }
        }
    }
    /* public int generateResources()
     * {
     * while (resourcesRemaining <= 0)
     * {
     * resourcesPerTick--;
     * }
       }
    */
}     

