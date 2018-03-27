using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TankBattle
{
    public class GameController
    {
		static Random rng = new Random();
		private int numPlayer;
		private int numRound;
		private TankModel[] TankController;
        private BattleTank[] Battletank;
        private int currentRound = 1;
        private int controller = 0;
        private Map map ; 

        public GameController(int numPlayers, int numRounds)
        { 
            numRound = numRounds;
			numPlayer = numPlayers;
            TankController = new TankModel[numPlayers];

            List<string> Effects = new List<string>();
        }

        public int TotalPlayers()
        {
			return numPlayer;
        }

        public int CurrentRound()
        {
			throw new NotImplementedException();
		}

        public int GetNumRounds()
        {
			return numRound;
        }

        public void RegisterPlayer(int playerNum, TankModel player)
        {
			TankController[playerNum - 1] = player;
        }

        public TankModel Player(int playerNum)
        {
            int playerNumber = playerNum;
			return TankController[playerNumber - 1];
		}

        public BattleTank PlayerTank(int playerNum)
        {
            throw new NotImplementedException();
        }

        public static Color GetTankColour(int playerNum)
        {
            int playerNumber = playerNum;
            List<Color> colours = new List<Color>();

            colours.Add(Color.LightSlateGray);
            colours.Add(Color.CadetBlue);
            colours.Add(Color.Tomato);
            colours.Add(Color.Violet);
            colours.Add(Color.Yellow);
            colours.Add(Color.DarkOliveGreen);
            colours.Add(Color.DarkOrange);
            colours.Add(Color.Aqua);
            colours.Add(Color.Red);
            colours.Add(Color.Pink);
            colours.Add(Color.LimeGreen);


            return (colours[playerNumber]);
        }


		public static int[] GetPlayerPositions(int numPlayers)
		{
			int distance = Map.WIDTH / numPlayers;
			int start = distance / 2;
			int[] PlayerPositions = new int[numPlayers];
			PlayerPositions[0] = start;
			int position = start;
			for (int i = 1; i < numPlayers; i++)
			{
				position = position + distance;
				PlayerPositions[i] = position;
			}

			return PlayerPositions;
		}

		public static void Rearrange(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				int store = array[i];
				int random = rng.Next(i, array.Length);
				array[i] = array[random];
				array[random] = store;
			}
		}

        public void StartGame()
        {
            throw new NotImplementedException();
           // NewRound();
        }

        public void NewRound()
        {
            map = GetLevel();
            int length = TankController.Length;
            Battletank = new BattleTank[length];
            int [] positions = GetPlayerPositions(length);


            for (int i = 0; i < length; i++)
            {
                TankController[i].StartRound();
            }
            Rearrange(positions);

        }

        public Map GetLevel()
        {
            throw new NotImplementedException();
        }

        public void DrawPlayers(Graphics graphics, Size displaySize)
        {
            throw new NotImplementedException();
        }

        public BattleTank GetCurrentGameplayTank()
        {
            throw new NotImplementedException();
        }

        public void AddWeaponEffect(Effect weaponEffect)
        {
            throw new NotImplementedException();
        }

        public bool WeaponEffectStep()
        {
            throw new NotImplementedException();
        }

        public void DisplayEffects(Graphics graphics, Size displaySize)
        {
            throw new NotImplementedException();
        }

        public void RemoveWeaponEffect(Effect weaponEffect)
        {
            throw new NotImplementedException();
        }

        public bool CheckHitTank(float projectileX, float projectileY)
        {
            throw new NotImplementedException();
        }

        public void InflictDamage(float damageX, float damageY, float explosionDamage, float radius)
        {
            throw new NotImplementedException();
        }

        public bool CalculateGravity()
        {
            throw new NotImplementedException();
        }

        public bool FinaliseTurn()
        {
            throw new NotImplementedException();
        }

        public void CheckWinner()
        {
            throw new NotImplementedException();
        }

        public void NextRound()
        {
            throw new NotImplementedException();
        }
        
        public int GetWind()
        {
            throw new NotImplementedException();
        }
    }
}
