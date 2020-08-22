using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace game.toyGame
{
    public class ToyCard : ICard
    { 

        public ToyCard(Bitmap image, string imageName)
        {
            this.Image = image;
            this.ImageName = imageName;
        }

        public Bitmap Image
        {
            get;
            set;
        }

        public string ImageName { get; set; }

    }
}
