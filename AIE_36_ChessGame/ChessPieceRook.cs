using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_ChessGame
{
    class ChessPieceRook : ChessPiece
    {
        public ChessPieceRook(ChessBoard board, EChessSide side, int row, int col) : 
            base(board, side, Type.ROOK, row, col)
        {

        }

        public override bool IsValidMove(int targetRow, int targetCol)
        {
            var targetPiece = board.GetPiece(targetRow, targetCol);
            if (targetPiece != null)
                return false;

            if (!(targetCol == GetCol() || targetRow == GetRow()))
                return false;

            int dX = GetCol() - targetCol;
            int dY = GetRow() - targetRow;

            if (dX > 0) dX = 1;
            if (dX < 0) dX = -1;
            if (dY > 0) dY = 1;
            if (dY < 0) dY = -1;

            int cX = targetCol;
            int cY = targetRow;

            while (!(cX == GetCol() && cY == GetRow()) && cX >= 0 && cX < 8 && cY >= 0 && cY < 8)
            {
                

                var pieceInSpot = board.GetPiece(cY, cX);

                if (pieceInSpot != null)
                {
                    return false;
                }

                cX += dX;
                cY += dY;
            }

            return true;
        }
    }
}

// trying to move it diagonally

//if (targetRow == GetRow() || targetCol == GetCol())
//{
//    for (int i = 1; i < 8; i++)
//    {
//        for (int j = 1; j < 8; j++)
//        {
//            if (GetCol() + i == targetCol && GetRow() + i == targetCol)
//                return true;
//        }
//    }
//}

//if (targetCol == GetCol())
//{
//    for (int i = 1; i < 8; i++)
//    {

//        if (GetRow() + i == targetRow)
//            return true;

//        if (GetRow() - i == targetRow)
//            return true;
//    }
//}

//if (targetRow == GetRow())
//{
//    for (int i = 1; i < 8; i++)
//    {
//        if (GetCol() + i == targetCol)
//            return true;

//        if (GetCol() - i == targetCol)
//            return true;
//    }
//}