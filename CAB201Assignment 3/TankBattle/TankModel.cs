using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
	
    public abstract class TankModel
    {
        public const int WIDTH = 4;
        public const int HEIGHT = 3;
        public const int NUM_TANKS = 1;

        public abstract int[,] DrawTankSprite(float angle);

        public static void CreateLine(int[,] graphic, int X1, int Y1, int X2, int Y2)
        {
            int w = X2 - X1;
            int h = Y2 - Y1;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                graphic[X1, Y1] = 1;
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    X1 += dx1;
                    Y1 += dy1;
                }
                else
                {
                    X1 += dx2;
                    Y1 += dy2;
                }
            }
        }


        public Bitmap CreateBMP(Color tankColour, float angle)
        {
            int[,] tankGraphic = DrawTankSprite(angle);
            int height = tankGraphic.GetLength(0);
            int width = tankGraphic.GetLength(1);

            Bitmap bmp = new Bitmap(width, height);
            Color transparent = Color.FromArgb(0, 0, 0, 0);
            Color tankOutline = Color.FromArgb(255, 0, 0, 0);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tankGraphic[y, x] == 0)
                    {
                        bmp.SetPixel(x, y, transparent);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, tankColour);
                    }
                }
            }

            // Outline each pixel
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    if (tankGraphic[y, x] != 0)
                    {
                        if (tankGraphic[y - 1, x] == 0)
                            bmp.SetPixel(x, y - 1, tankOutline);
                        if (tankGraphic[y + 1, x] == 0)
                            bmp.SetPixel(x, y + 1, tankOutline);
                        if (tankGraphic[y, x - 1] == 0)
                            bmp.SetPixel(x - 1, y, tankOutline);
                        if (tankGraphic[y, x + 1] == 0)
                            bmp.SetPixel(x + 1, y, tankOutline);
                    }
                }
            }

            return bmp;
        }

        public abstract int GetTankHealth();

        public abstract string[] WeaponList();

        public abstract void ShootWeapon(int weapon, BattleTank playerTank, GameController currentGame);

        public static TankModel GetTank(int tankNumber)
        {
			TankModel[] MyTanks = new TankModel[4];
			MyTanks[0] = new Aircraft_carrier();
			MyTanks[1] = new Battleship();
			MyTanks[2] = new Destroyer();
			MyTanks[3] = new Cruiser();
            Console.WriteLine(MyTanks[(tankNumber - 1)]);

			return MyTanks[(tankNumber - 1)];

		}
    }
	class Aircraft_carrier : TankModel
	{
        private int durability = 100;

        public override void CommenceTurn(GameForm gameplayForm, GameController currentGame)
        {
            throw new NotImplementedException();
        }

        public override int[,] DrawTankSprite(float angle)
		{
            int[,] graphic = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                               {0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                               {0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0 },
                               {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                               {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                               {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 } };
            Console.WriteLine(graphic.GetLength(0));
            Console.WriteLine(graphic.GetLength(1));
            if (angle <= -67.5)

            {
                CreateLine(graphic, 7, 5, X2:2, Y2:5);

            }
            else if (angle > -67.5 && angle <= -25)

            {
                CreateLine(graphic, 7, 5, X2:3, Y2:1);

            }
            else if (angle > -25 && angle <= 25)

            {
                CreateLine(graphic, 7, 5, X2: 5, Y2:2);

            }
            else if (angle > 25 && angle <= 50)
            {
                CreateLine(graphic, 7, 5, X2: 11, Y2: 2);

            }
            else if (angle > 50)

            {
                CreateLine(graphic, 7, 5,X2: 11,Y2: 3);
            }


            return graphic;
        }

		public override int GetTankHealth()
		{
            return durability;
		}

        public override void ReportHit(float x, float y)
        {
            throw new NotImplementedException();
        }

        public override void ShootWeapon(int weapon, BattleTank playerTank, GameController currentGame)
		{
			throw new NotImplementedException();
		}

        public override void StartRound()
        {
            throw new NotImplementedException();
        }

        public override string[] WeaponList()
		{
            return new string[] {"Standard Shell", "Harpoon" };
		}
	}
	class Battleship : TankModel { 
		public override int[,] DrawTankSprite(float angle)
		{
            int[,] graphic = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                               {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                               {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                               {0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }};

            Console.WriteLine(graphic.GetLength(0));
            Console.WriteLine(graphic.GetLength(1));
            if (angle <= -67.5)

            {
                CreateLine(graphic, 8, 5, X2:2, Y2:5);

            }
            else if (angle > -67.5 && angle <= -25)

            {
                CreateLine(graphic, 8, 5, X2:1, Y2:1);

            }
            else if (angle > -25 && angle <= 25)

            {
                CreateLine(graphic, 8, 5, X2:11, Y2:2);

            }
            else if (angle > 25 && angle <= 50)
            {
                CreateLine(graphic, 8, 5, X2:11, Y2:2);

            }
            else if (angle > 50)

            {
                CreateLine(graphic, 13, 5, X2:12, Y2:3);
            }

            return graphic;
        }

		public override int GetTankHealth()
		{
            return 150;
		}

		public override void ShootWeapon(int weapon, BattleTank playerTank, GameController currentGame)
		{
			throw new NotImplementedException();
		}

		public override string[] WeaponList()
		{
            return new string[] { "Standard Shell", "Harpoon", "Heavy Shell" };
        }
	}
	class Destroyer : TankModel
	{
        
        public override int[,] DrawTankSprite(float angle)
		{
            int[,] graphic = {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
                               {0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
                               {0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1 },
                               {0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1 },
                               {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                               {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                               {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 }};
            if (angle <= -67.5)

            {
                CreateLine(graphic, 5, 5, 2, 5);

            }
            else if (angle > -67.5 && angle <= -25)

            {
                CreateLine(graphic, 6, 5, X2:1, Y2:1);

            }
            else if (angle > -25 && angle <= 25)

            {
                CreateLine(graphic, 6, 5, X2:5, Y2:2);

            }
            else if (angle > 25 && angle <= 50)
            {
                CreateLine(graphic, 6, 5, X2:11, Y2:2);

            }
            else if (angle > 50)

            {
                CreateLine(graphic, 6, 5, X2:11, Y2:3);
            }
            return graphic;
        }

		public override int GetTankHealth()
		{
            return 80;
		}

		public override void ShootWeapon(int weapon, BattleTank playerTank, GameController currentGame)
		{
			throw new NotImplementedException();
		}

		public override string[] WeaponList()
		{
            return new string[] { "Harpoon", "Heavy Shell" };
        }
	}
	class Cruiser : TankModel
	{

        public override int[,] DrawTankSprite(float angle)
		{
            int[,] graphic = { {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                               {0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0 },
                               {0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0 },
                               {0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0 },
                               {0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0 },
                               {0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0 },
                               {0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                               {0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 }};
            if (angle <= -67.5)

            {
                CreateLine(graphic, 8, 4, X2:3, Y2:4);

            } else if (angle > -67.5 && angle <= -25)

            {
                CreateLine(graphic, 8, 4, X2:3, Y2:2);

            } else if (angle > -25 && angle <= 25)

            {
                CreateLine(graphic, 8, 4, X2:8, Y2:2); 
                  
            } else if (angle > 25 && angle <= 50)
            {
                CreateLine(graphic, 8, 4, X2: 11, Y2: 2);

            } else if (angle > 50)

            {
                CreateLine(graphic, 8, 4, X2:11, Y2:4);
            }
            return graphic;
            
        }

		public override int GetTankHealth()
		{
            return 95;
		}

		public override void ShootWeapon(int weapon, BattleTank playerTank, GameController currentGame)
		{
			throw new NotImplementedException();
		}

		public override string[] WeaponList()
		{
            return new string[] { "Standard Shell", "Harpoon"};
        }
	}
}
