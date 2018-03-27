using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    public abstract class Effect
    {
        protected GameController currentgame;
        public void SetCurrentGame(GameController game)
        {
            currentgame = game;
        }

        public abstract void Step();
        public abstract void Display(Graphics graphics, Size displaySize);
    }
}
