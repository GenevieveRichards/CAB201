using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    public class PlayerController : TankModel
    {
        public PlayerController(string name, TankModel tank, Color colour) : base(name, tank, colour)
        { }

        public override void StartRound()
        {
        }

        public override void CommenceTurn(GameForm gameplayForm, GameController currentGame)
        {
            throw new NotImplementedException();
        }

        public override void ReportHit(float x, float y)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
