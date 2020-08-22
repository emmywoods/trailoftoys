using System;
using System.Collections.Generic;
using System.Text;

namespace game.toyGame
{
    public class ColorCard : ICard
    {
        Random _rnd;
        private System.Drawing.Color _color;
        private int _numSquares;

        public System.Drawing.Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                int colorInt = _rnd.Next(0, 5);
                if (colorInt == 0)
                    this._color = System.Drawing.Color.Red;
                else if (colorInt == 1)
                    this._color = System.Drawing.Color.Orange;
                else if (colorInt == 2)
                    this._color = System.Drawing.Color.Yellow;
                else if (colorInt == 3)
                    this._color = System.Drawing.Color.Green;
                else if (colorInt == 4)
                    this._color = System.Drawing.Color.Blue;
                else if (colorInt == 5)
                    this._color = System.Drawing.Color.Purple;
            }
        }

        public int NumSquares
        {
            get
            {
                return _numSquares;
            }
            set
            {
                if (value == 0)
                    _numSquares = 1;
                else
                    _numSquares = 2;
            }
        }

        public ColorCard(Random rnd)
        {
            this._rnd = rnd;
            this.Color = System.Drawing.Color.Red; // the property will set it randomly...
            this.NumSquares = _rnd.Next(0, 2);
        }
    }
}
