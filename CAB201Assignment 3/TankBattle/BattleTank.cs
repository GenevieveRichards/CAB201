using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public class BattleTank
    {
        private TankModel bPlayer;
        private int tankx;
        private int tanky;
        private GameController currentgame;
        private float angle;
        private int power;
        private int currentweapon;
        private Bitmap currenttank;
        public BattleTank(TankModel player, int tankX, int tankY, GameController game)
        {
            bPlayer = player;
            tankx = tankX;
            tanky = tankY;
            currentgame = game;

            TankModel current = GetTank();
            int durability = current.GetTankHealth();
            angle = 0;
            power = 25;
            currentweapon = 0;

            TankModel.TankColour();
        
        }

        public TankModel Player()
        {
            throw new NotImplementedException();
        }
        public TankModel GetTank()
        {
            throw new NotImplementedException();
        }

        public float GetAim()
        {
            throw new NotImplementedException();
        }

        public void SetAimingAngle(float angle)
        {
            throw new NotImplementedException();
        }

        public int GetTankPower()
        {
            throw new NotImplementedException();
        }

        public void SetPower(int power)
        {
            throw new NotImplementedException();
        }

        public int GetPlayerWeapon()
        {
            throw new NotImplementedException();
        }
        public void SetWeapon(int newWeapon)
        {
            throw new NotImplementedException();
        }

        public void Display(Graphics graphics, Size displaySize)
        {
            throw new NotImplementedException();
        }

        public int XPos()
        {
            throw new NotImplementedException();
        }
        public int Y()
        {
            throw new NotImplementedException();
        }

        public void Launch()
        {
            throw new NotImplementedException();
        }

        public void InflictDamage(int damageAmount)
        {
            throw new NotImplementedException();
        }

        public bool IsAlive()
        {
            throw new NotImplementedException();
        }

        public bool CalculateGravity()
        {
            throw new NotImplementedException();
        }
    }
}
