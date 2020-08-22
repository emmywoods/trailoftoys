using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace game.toyGame
{
    class ComputerPlayer : Player
    {

        public ComputerPlayer(Bitmap avatar, string name, PictureBox fullAv, PictureBox border) : base(avatar, name, fullAv, border)
        {

        }

        public void PlayTurn()
        {
            throw new NotImplementedException();
        }
    }
}
