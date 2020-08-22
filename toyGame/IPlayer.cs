using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace game.toyGame
{
    public interface IPlayer
    {

        int NextPosition { get; set; }

        string Name
        {
            get;
            set;
        }

        Bitmap Avatar
        {
            get;
            set;
        }

        int? Position
        {
            get;
            set;
        }

        PictureBox FullAvatar { get; set; }
        PictureBox Border { get; set; }

        void DetermineNextPosition(ToyCard Card, List<IPlayer> Players);

        void DetermineNextPosition(ColorCard Card, List<IPlayer> Players);
    }
}
