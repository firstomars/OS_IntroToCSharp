using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_ChessGame
{
    class ChessPieceBishop : ChessPiece
    {
        public ChessPieceBishop(ChessBoard board, EChessSide side, int row, int col) : 
            base(board, side, Type.BISHOP, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {

            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null && targetPiece.GetSide() == GetSide())
                return false;

            for (int i = 1; i < 8; i++)
            {
                if (GetRow() + i == targetRow && GetCol() + i == targetCol)
                {
                    return true;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (GetRow() - i == targetRow && GetCol() - i == targetCol)
                {
                    return true;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (GetRow() + i == targetRow && GetCol() - i == targetCol)
                {
                    return true;
                }
            }

            for (int i = 1; i < 8; i++)
            {
                if (GetRow() - i == targetRow && GetCol() + i == targetCol)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
