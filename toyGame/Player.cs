using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace game.toyGame
{
    abstract class Player : IPlayer
    {
        public string Name { get; set; }
        protected int _nextPosition;
        protected int? _position;
        protected int _offset;
        protected Bitmap _avatar;

        public PictureBox FullAvatar { get; set; }
        public PictureBox Border { get; set; }

        protected static int numPlayers = 0;

        public Bitmap Avatar
        {
            get
            {
                return this._avatar;
            }
            set
            {
                _avatar = value;
            }
        }

        public int? Position
        {
            get
            {
                return _position;
            }
            set
            {
                this._position = value;
            }
        }

        public int NextPosition
        {
            get
            {
                return _nextPosition;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public Player(Bitmap avatar, string name, PictureBox fullAv, PictureBox border)
        {
            this._offset = numPlayers++;
            this.Border = border;
            this.FullAvatar = fullAv;
            this.Name = name;
            this.Avatar = avatar;
            this._position = null; // at the start button
        }

        public void DetermineNextPosition(ColorCard Card, List<IPlayer> Players)
        {
            // DetermineNextPosition determines where the player is supposed to move to.
            // Each color is made up of 4 squares. There are 6 colors, and one 4-square toy, then repeat.
            // That's why it's mod 28.
            int modPosition;
            if (this.Position == null)
                modPosition = -1;
            else
                modPosition = Position % 28 ?? 0;
            int destination = 0; // Red
            if (Card.Color == Color.Orange) destination = 4;
            else if (Card.Color == Color.Yellow) destination = 8;
            else if (Card.Color == Color.Green) destination = 12;
            else if (Card.Color == Color.Blue) destination = 16;
            else if (Card.Color == Color.Purple) destination = 20;

            if (destination <= modPosition) destination += 28;

            int displacement = destination - modPosition;
            // if they're moving two squares of that color, add 28
            if (Card.NumSquares == 2) displacement += 28;
            this._nextPosition = (Position ?? -1) + displacement + _offset;
            // square 200 is the winner square, don't let them go past it
            if (this._nextPosition > 200) this._nextPosition = 200;

            /*
            // make sure the position isn't already occupied
            foreach (IPlayer p in Players)
            {
                if (p.Position == this._nextPosition)
                {
                    this._offset += 1;
                    this._nextPosition += 1;
                }
            }
            */
        }

        public void DetermineNextPosition(ToyCard Card, List<IPlayer> Players)
        {
            // the positions of the toy cards are hardcoded
            if (Card.ImageName == "basketball") this._nextPosition = 24;
            else if (Card.ImageName == "car") this._nextPosition = 24 + 28;
            else if (Card.ImageName == "keyboard") this._nextPosition = 24 + 28 * 2;
            else if (Card.ImageName == "dinosaur") this._nextPosition = 24 + 28 * 3;
            else if (Card.ImageName == "teddybear") this._nextPosition = 24 + 28 * 4;
            else if (Card.ImageName == "tricycle") this._nextPosition = 24 + 28 * 5;
            else if (Card.ImageName == "blocks") this._nextPosition = 24 + 28 * 6;
            //else if (Card.ImageName == "drum") this._nextPosition = 24 + 28 * 8;
            this._nextPosition += this._offset;

            /*
            // make sure the position isn't already occupied
            foreach (IPlayer p in Players)
            {
                if (p.Position == this._nextPosition)
                {
                    this._offset += 1;
                    this._nextPosition += 1;
                }
            }*/
        }
    }
}
