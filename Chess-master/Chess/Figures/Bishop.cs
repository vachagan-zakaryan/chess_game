using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : ChessPiece
    {
        public Bishop(int x, int y, bool isBlack) : base(x, y, isBlack) { }

        public override string imageName()
        {
            if (isBlack) return "Images/b_bishop.png";
            else return "Images/w_bishop.png";
        }

        public override List<ChessPoint> getPossibleHits(List<ChessPiece> allPieces)
        {
            List<ChessPoint> allMoves = new List<ChessPoint>();
            for (int i = position.X - 1, j = position.Y - 1; i >= 0 && j >= 0; i--, j--)
            {
                allMoves.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X - 1, j = position.Y + 1; i >= 0 && j < 8; i--, j++)
            {
                allMoves.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X + 1, j = position.Y - 1; i < 8 && j >= 0; i++, j--)
            {
                allMoves.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X + 1, j = position.Y + 1; i < 8 && j < 8; i++, j++)
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
            for (int i = position.X - 1, j = position.Y - 1; i >= 0 && j >= 0; i--, j--)
            {
                result.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X - 1, j = position.Y + 1; i >= 0 && j < 8; i--, j++)
            {
                result.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X + 1, j = position.Y - 1; i < 8 && j >= 0; i++, j--)
            {
                result.Add(new ChessPoint(i, j));
                if (hasCollision(allPieces, i, j))
                {
                    break;
                }
            }
            for (int i = position.X + 1, j = position.Y + 1; i < 8 && j < 8; i++, j++)
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
