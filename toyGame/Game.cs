using System;
using System.Collections.Generic;
using System.Text;

namespace game.toyGame
{
    public class Game
    {
        List<IPlayer> Players;
        List<ICard> Path;

        public Game(List<IPlayer> players)
        {
            throw new NotImplementedException();
        }

        public int WhoseTurn
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICard CardInPlay
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CheckPlayerChoice(int CardSelected)
        {
            throw new NotImplementedException();
        }
    }
}
