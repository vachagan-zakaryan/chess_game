using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : ChessPiece
    {
        public Knight(int x, int y, bool isBlack) : base(x, y, isBlack) { }

        public override string imageName()
        {
            if (isBlack) return "Images/b_knight.png";
            else return "Images/w_knight.png";
        }

        public override List<ChessPoint> getPossibleHits(List<ChessPiece> allPieces)
        {
            List<ChessPoint> allMoves = new List<ChessPoint>();
            if (position.X - 2 >= 0 && position.Y - 1 >= 0)
            {
                allMoves.Add(new ChessPoint(position.X - 2, position.Y - 1));
            }
            if (position.X - 2 >= 0 && position.Y + 1 < 8)
            {
                allMoves.Add(new ChessPoint(position.X - 2, position.Y + 1));
            }
            if (position.X + 2 < 8 && position.Y - 1 >= 0)
            {
                allMoves.Add(new ChessPoint(position.X + 2, position.Y - 1));
            }
            if (position.X + 2 < 8 && position.Y + 1 < 8)
            {
                allMoves.Add(new ChessPoint(position.X + 2, position.Y + 1));
            }
            if (position.X - 1 >= 0 && position.Y - 2 >= 0)
            {
                allMoves.Add(new ChessPoint(position.X - 1, position.Y - 2));
            }
            if (position.X - 1 >= 0 && position.Y + 2 < 8)
            {
                allMoves.Add(new ChessPoint(position.X - 1, position.Y + 2));
            }
            if (position.X + 1 < 8 && position.Y - 2 >= 0)
            {
                allMoves.Add(new ChessPoint(position.X + 1, position.Y - 2));
            }
            if (position.X + 1 < 8 && position.Y + 2 < 8)
            {
                allMoves.Add(new ChessPoint(position.X + 1, position.Y + 2));
            }
            List<ChessPoint> result = new List<ChessPoint>();
            foreach (ChessPiece cp in allPieces)
            {
                if (isBlack != cp.isBlack && allMoves.Contains(cp.position))
                {
                    result.Add(cp.position);
                }
            }
            return result;
        }

        public override List<ChessPoint> getPossibleMoves(List<ChessPiece> allPieces)
        {
            List<ChessPoint> result = new List<ChessPoint>();
            if (position.X - 2 >= 0 && position.Y - 1 >= 0)
            {
                result.Add(new ChessPoint(position.X - 2, position.Y - 1));
            }
            if (position.X - 2 >= 0 && position.Y + 1 < 8)
            {
                result.Add(new ChessPoint(position.X - 2, position.Y + 1));
            }
            if (position.X + 2 < 8 && position.Y - 1 >= 0)
            {
                result.Add(new ChessPoint(position.X + 2, position.Y - 1));
            }
            if (position.X + 2 < 8 && position.Y + 1 < 8)
            {
                result.Add(new ChessPoint(position.X + 2, position.Y + 1));
            }
            if (position.X - 1 >= 0 && position.Y - 2 >= 0)
            {
                result.Add(new ChessPoint(position.X - 1, position.Y - 2));
            }
            if (position.X - 1 >= 0 && position.Y + 2 < 8)
            {
                result.Add(new ChessPoint(position.X - 1, position.Y + 2));
            }
            if (position.X + 1 < 8 && position.Y - 2 >= 0)
            {
                result.Add(new ChessPoint(position.X + 1, position.Y - 2));
            }
            if (position.X + 1 < 8 && position.Y + 2 < 8)
            {
                result.Add(new ChessPoint(position.X + 1, position.Y + 2));
            }
            List<ChessPoint> invalidMoves = new List<ChessPoint>();
            foreach (ChessPiece cp in allPieces)
            {
                foreach (ChessPoint possibleMove in result)
                {
                    if (cp.position.X == possibleMove.X && cp.position.Y == possibleMove.Y)
                    {
                        invalidMoves.Add(possibleMove);
                    }
                }
            }
            foreach (ChessPoint invalidMove in invalidMoves)
            {
                result.Remove(invalidMove);
            }
            return result;
        }
    }
}
