using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_ChessGame
{
    class ChessPiecePawn : ChessPiece
    {
        public ChessPiecePawn(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.PAWN, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {

            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null && targetPiece.GetSide() == GetSide())
                return false;

            if (GetSide() == EChessSide.WHITE)
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() + 1 == targetRow)
                        return true;
                }
            }
            else
            {
                if (targetCol == GetCol())
                {
                    if (GetRow() - 1 == targetRow)
                        return true;
                }
            }

            return false;
        }
    }
}
