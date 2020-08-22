using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace game.toyGame
{
    class HumanPlayer : Player
    {
        public bool CorrectChoice { get; private set; }

        new public int? Position
        {
            get
            {
                return _position;
            }
            set
            {
                // I need to check that the square the user selected is within the 4 square set
                if (value > NextPosition - 1 - _offset && value < NextPosition + 4 - _offset)
                {
                    this._position = value;
                    this.CorrectChoice = true;
                }
                else
                    this.CorrectChoice = false;
            }
        }

        public HumanPlayer(Bitmap avatar, string name, PictureBox fullAv, PictureBox border) : base(avatar, name, fullAv, border)
        {
            
        }

        
    }
}
