using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GadeAssignment1
{
    class Map
    {
        private const int MAX_RANDOM_UNITS = 50;
        public const string FIELD_SYMBOL = ".";
        public string[,] grid = new string[20, 20];
        private List<Unit> unitsonMap = new List<Unit>();
        private int numberofUnitsOnMap = 0;

        public string[,] Grid
        {
            get
            {
                return grid;
            }
        }

        public List<Unit> UnitsOnMap
        {
            get
            {
                return unitsonMap;
            }
        }

        public void populate()
        {
            Random rnd = new Random();
            int numberRandomUnits = rnd.Next(0, MAX_RANDOM_UNITS) + 1;
            int x, y, randomAttackRange;
            bool attackOption;
            string team;

            //clear Field
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    grid[i, j] = FIELD_SYMBOL;
                }
            }

            for (int k = 1; k <= numberRandomUnits; k++)
            {
                //Ensure x, y is not occupied by another unit
                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                } while (grid[x, y] != FIELD_SYMBOL);

                //generate randomly either a meleeunit or rangedunit and place on map
                if (rnd.Next(1, 3) == 1)
                {
                    attackOption = rnd.Next(0, 2) == 1 ? true : false;        //Randomize attack option
                    team = rnd.Next(0, 2) == 1 ? "RED" : "GREEN";
                    Unit tmp = new MeleeUnit(x, y, 100, -1, attackOption, 1, team, "M");
                    unitsonMap.Add(tmp);


                    grid[x, y] = tmp.Symbol;

                    //update arraySize
                    numberofUnitsOnMap++;
                }
                else
                {
                    attackOption = rnd.Next(0, 2) == 1 ? true : false;
                    randomAttackRange = rnd.Next(1, 20);
                    team = rnd.Next(0, 2) == 1 ? "RED" : "GREEN";
                    Unit tmp = new RangedUnit(x, y, 100, -1, attackOption, randomAttackRange, team, "R");
                    unitsonMap.Add(tmp);

                    grid[x, y] = unitsonMap[numberofUnitsOnMap].Symbol;

                    //update arraySize
                    numberofUnitsOnMap++;
                }
            }

        }

        private void moveOnMap(Unit u, int newX, int newY)
        {
            grid[u.X, u.Y] = FIELD_SYMBOL;
            grid[newX, newY] = u.Symbol;
        }

        public void update(Unit u, int newX, int newY)
        {
            if ((newX >= 0 && newX < 20) && (newY >= 0 && newY < 20))
            {
                moveOnMap(u, newX, newY);
                u.move(newX, newY);
            }
        }

        public void checkHealth()
        {
            for (int i = 0; i < numberofUnitsOnMap; i++)
            {
                if (!unitsonMap[i].isAlive())
                {
                    grid[unitsonMap[i].X, unitsonMap[i].Y] = FIELD_SYMBOL;  //remove unit from grid
                    unitsonMap.RemoveAt(i);          //remove unit from list
                    numberofUnitsOnMap--;
                }
            }
        }
        public void save()
        {

        }
    }
}





