using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDelEveLamLINQ
{
    partial class SticksGame
    {
        private readonly Random randomizer;

        public int InitialSticksNumber { get; }

        public Player Turn { get; private set; }

        public int RemainingSticks { get; private set; }

        public GameStatus gameStatus { get; private set; }

        public event Action<int> MachinePLayed;
        public event EventHandler<int> HumanTurnToMakeMove;

        public event Action<Player> EndOfGame;

        public SticksGame(int initialSticksNumber, Player whoMakesFirstMove)
        {
            if (initialSticksNumber < 7 || initialSticksNumber > 30)
                throw new ArgumentException("Initial number of sticks should be >= 7 and <= 30");
            randomizer = new Random();
            gameStatus = GameStatus.NotStarted;
            InitialSticksNumber = initialSticksNumber;
            RemainingSticks = InitialSticksNumber;
            Turn = whoMakesFirstMove;
        }

        public void Start()
        {
            if(gameStatus == GameStatus.InProgress)
            {
                RemainingSticks = InitialSticksNumber;
            }
            if(gameStatus == GameStatus.InProgress)
            {
                throw new InvalidOperationException("Can't call Start when game is already in progress");
            }

            gameStatus = GameStatus.InProgress;
            while(gameStatus == GameStatus.InProgress)
            {
                if(Turn == Player.Computer)
                {
                    ComputerMakesMove();
                }
                else
                {
                    HumanMakesMove();
                }
                FireEndOfGameIfRequired();

                Turn = Turn == Player.Computer ? Player.Human : Player.Computer;
            }
        }

        private void FireEndOfGameIfRequired()
        {
            if(RemainingSticks == 0)
            {
                gameStatus = GameStatus.GameIsOver;
                if (EndOfGame != null)
                    EndOfGame(Turn == Player.Computer ? Player.Human : Player.Computer);
            }
        }

        public void HumanTakes(int sticks)
        {
            if(sticks<1 || sticks > 3)
            {
                throw new ArgumentException("You can take from 1 to 3 in single move.");
            }
            if(sticks > RemainingSticks)
            {
                throw new ArgumentException($"You cant take more than remaining. Remains:{RemainingSticks}.");
            }
            TakeSticks(sticks);
        }

        private void HumanMakesMove()
        {
            if (HumanTurnToMakeMove != null)
                HumanTurnToMakeMove(this, RemainingSticks);
        }
        private void ComputerMakesMove()
        {
            int maxNumber = RemainingSticks >= 3 ? 3 : RemainingSticks;
            int sticks = randomizer.Next(1, maxNumber);

            TakeSticks(sticks);
            if (MachinePLayed != null)
                MachinePLayed(sticks);
        }

        private void TakeSticks(int sticks)
        {
            RemainingSticks -= sticks;
        }
    }
}
