using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    abstract public class TankModel
    {
        private string names;
        private TankModel tanks;
        private Color color;
        private int wonRounds = 0;

        public TankModel(string name, TankModel tank, Color colour)
        {
            names = name;
            tanks = tank;
            color = colour;
        }
        public TankModel GetTank()
        {
            return tanks;
        }
        public string GetName()
        {
            return names;
        }
        public Color TankColour()
        {
            return color;
        }
        public void AddPoint()
        {
            wonRounds++;
        }
        public int GetWins()
        {
            return wonRounds;
        }

        public abstract void StartRound();

        public abstract void CommenceTurn(GameForm gameplayForm, GameController currentGame);

        public abstract void ReportHit(float x, float y);
    }
}
