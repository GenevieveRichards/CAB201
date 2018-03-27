using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public class Map
    {
        private bool[,] terrain;
        public const int WIDTH = 160;
        public const int HEIGHT = 120;

        static Random rng = new Random();

        public Map()
        {
            terrain = new bool[WIDTH, HEIGHT];
            int randomNumbery;
            //Putting terrain on the bottom row
            for (int i = 0; i < WIDTH; i++)
            {
                terrain[i, (HEIGHT - 1)] = true;
                //Console.Write("true" + i + ',' + (HEIGHT -1));
            }
            //parsing all x coordinate and all y 
            //Console.WriteLine();

            for (int i = 0; i < WIDTH; i++)
            {

                for (int j = (HEIGHT - 2); j > TankModel.HEIGHT; j--)
                {
                    randomNumbery = rng.Next(0, 2);
                    //Checking to make sure there if terrain under, if not no terrain allowed above 
                    if (terrain[i, j + 1] == false)
                    {
                        terrain[i, j] = false;
                        //Console.Write("false" + i + ',' + j);
                    }
                    //if the randomNumber is 1 then bool is true
                    else if (randomNumbery == 1)
                    {
                        terrain[i, j] = true;
                        //Console.Write("true" + i + ',' + j);
                    }
                    //if the randomNumber is 1, bool is false
                    else if (randomNumbery == 0)
                    {
                        terrain[i, j] = false;
                        //Console.Write("false" + i + ',' + j);
                    }

                }
                //Console.WriteLine();

            }
        }

        public bool TileAt(int x, int y)
        {

            if (terrain[x, y] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TankFits(int x, int y)
        {
            int counter = 0;
            for (int X = x; X < (x + TankModel.WIDTH); X++)
            {
                for (int Y = y; Y < (y + TankModel.HEIGHT); Y++)
                {
                    if (TileAt(X,Y) == true) { counter++; }
                }
            }
            if (counter > 0) { return true; }
            else { return false; }
        }

        public int TankYPosition(int x)
        {
            bool check = false;
            List<int> Y = new List<int>();
            int y = 0;

            do {
                    if (TankFits(x, y) == true)
                    {
                        Y.Add(y);
                        check = true;

                    }
                y++;
            } while (check == false);
            return (Y[0] -1);
        
        }

        public void TerrainDestruction(float destroyX, float destroyY, float radius)
        {
            float x2 = destroyX;
            float y2 = destroyY;
            float R = radius;
            
            for (int y = (HEIGHT - 1); y >= 0; y --)
            {
                for (int x = 0; x < (WIDTH - 1); x ++)
                {
                    float dx = (float)Math.Pow(x - x2, 2);
                    float dy = (float)Math.Pow(y - y2, 2);
                    float distance = (float)Math.Sqrt(dx + dy);
                    if (distance <= (R))
                    {
                        terrain[x, y] = false;
                        Console.WriteLine(terrain[x, y]);
                        Console.WriteLine("("+ x + "," + y +")");
                    }
                }
            }
        }

        public bool CalculateGravity()
        {
            int counter = 0;
            for (int x = 0; x < (WIDTH - 1); x++)
            {
                for (int y = (HEIGHT -2); y >=0; y--)
                {
                    bool value = terrain[x, (y + 1)];
                    bool current = terrain[x, y];
                    if (terrain[x, y] == true)
                        
                    {
                        if (terrain[x, (y + 1)] == false)
                        {
                            terrain[x, (y + 1)] = true;
                            terrain[x, y] = false;
                            counter++;
                        }
                    }
                }

            }
            if (counter > 0) { return true; }
            else { return false; }

        }
    }
}
