using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GadeAssignment1
{
    class RangedUnit : Unit
    {
        private const int DAMAGE = 2;

        // Constructor
        public RangedUnit(int x, int y, int health, int speed, bool attack, int attackRange, string faction, string symbol, string name = "Marksman")
            : base(x, y, health, speed, attack, attackRange, faction, symbol, name)
        {

        }

        public override void move(int x, int y)
        {
            if (x >= 0 && x < 20)
                X = x;
            if (y >= 0 && y < 20)
                Y = y;


        }
        public override void combat(Unit enemy)
        {
            if (this.isInRange(enemy))
            {
                enemy.Health -= DAMAGE;
            }
        }
        public override bool isInRange(Unit enemy)
        {
            if ((Math.Abs(this.X - enemy.X) <= this.attackRange) || (Math.Abs(this.X - enemy.X) <= attackRange))
                return true;
            else
                return false;
        }
        public override Unit nearestUnit(List<Unit> list)
        {
            Unit closest = null;

            int attackRangeX, attackRangeY;
            int shortestRange = 4000;

            foreach (Unit u in list)
            {
                attackRangeX = Math.Abs(this.X - u.X);
                attackRangeY = Math.Abs(this.Y - u.Y);

                if (attackRangeX < shortestRange)
                {
                    shortestRange = attackRangeX;
                    closest = u;
                }
                if (attackRangeY < shortestRange)
                {
                    shortestRange = attackRangeY;
                    closest = u;
                }
            }
            return closest;
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
                + "Faction/Team: " + faction + Environment.NewLine
                + "Name; " + name + Environment.NewLine;
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
                    rf.WriteLine(speed);
                    rf.WriteLine(attack);
                    rf.WriteLine(attackRange);
                    rf.WriteLine(faction);
                    rf.WriteLine(symbol);
                    rf.WriteLine(name);

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
}


