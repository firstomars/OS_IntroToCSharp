using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_ChessGame
{
    class ChessPieceKnight : ChessPiece
    {
        public ChessPieceKnight(ChessBoard board, EChessSide side, int row, int col) :
            base(board, side, Type.KNIGHT, row, col)
        {

        }
        public override bool IsValidMove(int targetRow, int targetCol)
        {

            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null && targetPiece.GetSide() == GetSide())
                return false;

            if (GetRow() + 2 == targetRow && GetCol() + 1 == targetCol)
                return true;

            if (GetRow() + 2 == targetRow && GetCol() - 1 == targetCol)
                return true;

            if (GetRow() - 2 == targetRow && GetCol() + 1 == targetCol)
                return true;

            if (GetRow() - 2 == targetRow && GetCol() - 1 == targetCol)
                return true;

            if (GetRow() + 1 == targetRow && GetCol() + 2 == targetCol)
                return true;

            if (GetRow() - 1 == targetRow && GetCol() - 2 == targetCol)
                return true;

            if (GetRow() + 1 == targetRow && GetCol() - 2 == targetCol)
                return true;

            if (GetRow() - 1 == targetRow && GetCol() + 2 == targetCol)
                return true;

            return false;
        }
    }
}
