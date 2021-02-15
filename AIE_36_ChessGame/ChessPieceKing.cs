using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_ChessGame
{
    class ChessPieceKing : ChessPiece
    {
        public ChessPieceKing(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.KING, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            var targetPiece = board.GetPiece(targetRow, targetCol);

            if (targetPiece != null && targetPiece.GetSide() == GetSide())
                return false;
            // if the board tile does not exist and the target piece is the same colour as you - return null;

            if (GetRow() + 1 == targetRow && targetCol == GetCol())
            {
                return true;
            }

            if (GetRow() - 1 == targetRow && targetCol == GetCol())
            {
                return true;
            }

            if (GetCol() + 1 == targetCol && targetRow == GetRow())
            {
                return true;
            }

            if (GetCol() - 1 == targetCol && targetRow == GetRow())
            {
                return true;
            }

            return false;
        }

    }
}
