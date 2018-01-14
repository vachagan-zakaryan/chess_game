using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessPoint : IEquatable<ChessPoint>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ChessPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(ChessPoint other)
        {
            if(this.X == other.X && this.Y == other.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
