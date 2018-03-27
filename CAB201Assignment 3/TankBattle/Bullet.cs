using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    public class Bullet : Effect
    {
        float X;
        float Y;
        float angles;
        float powers;
        float gravitys;
        Shrapnel explosions;
        TankModel players;
        float dx;
        float dy; 
        public Bullet(float x, float y, float angle, float power, float gravity, Shrapnel explosion, TankModel player)
        {
            X = x;
            Y = y;
            angles = angle;
            powers = power;
            gravitys = gravity;
            explosions = explosion;
            players = player;
            float angleRadians = (90 - angle) * (float)Math.PI / 180;
            float magnitude = power / 50;
            dx = (float)Math.Cos(angleRadians) * magnitude;
            dy = (float)Math.Sin(angleRadians) * (-magnitude);
        }

        public override void Step()
        {
            throw new NotImplementedException();
        }

        public override void Display(Graphics graphics, Size size)
        {
            throw new NotImplementedException();
        }
    }
}
