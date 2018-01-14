using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : ChessPiece
    {
        public Rook(int x, int y, bool isBlack) : base(x, y, isBlack) { }

        public override string imageName()
        {
            if (isBlack) return "Images/b_rook.png";
            else return "Images/w_rook.png";
        }

        public override List<ChessPoint> getPossibleHits(List<ChessPiece> allPieces)
        {
            List<ChessPoint> allMoves = new List<ChessPoint>();
            for (int i = position.X - 1, j = position.Y; i >= 0; i--)
            {
                allMoves.Add(new ChessPoint(i, j));
                if(hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X + 1, j = position.Y; i < 8; i++)
            {
                allMoves.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X, j = position.Y - 1; j >= 0; j--)
            {
                allMoves.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X, j = position.Y + 1; j < 8; j++)
            {
                allMoves.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
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
            for (int i = position.X - 1, j = position.Y; i >= 0; i--)
            {
                result.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X + 1, j = position.Y; i < 8; i++)
            {
                result.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X, j = position.Y - 1; j >= 0; j--)
            {
                result.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X, j = position.Y + 1; j < 8; j++)
            {
                result.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
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
