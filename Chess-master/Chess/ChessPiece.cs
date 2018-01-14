using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract class ChessPiece
    {

        public abstract string imageName();

        public bool isFrist = true;

        public ChessPiece(int x , int y, bool isBlack)
        {
            position = new ChessPoint(x, y);
            isFrist = true;
            this.isBlack = isBlack;
        }

        public bool hasCollision(List<ChessPiece> allPieces, int x, int y)
        {
            foreach (ChessPiece cp in allPieces)
            {
                if (cp.position.X == x && cp.position.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private ChessPoint _position;
        public ChessPoint position {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                isFrist = false;
            }
        }

        public bool isBlack { get; set; }

        public abstract List<ChessPoint> getPossibleMoves(List<ChessPiece> allPieces);

        public abstract List<ChessPoint> getPossibleHits(List<ChessPiece> allPieces);
    }
}
