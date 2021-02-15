using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_36_ChessGame
{
    class ChessPiece
    {
        public enum Type
        {
            PAWN,
            CASTLE,
            BISHOP,
            ROOK,
            KNIGHT,
            QUEEN,
            KING
        }

        protected ChessBoard board;

        EChessSide side;
        int row;
        int col;
        Type type;
        //public int[] all = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        
        public ChessPiece(ChessBoard board, EChessSide side, Type type, int row, int col)
        {
            this.board = board;
            this.side = side;
            this.type = type;
            this.row = row;
            this.col = col;
        }

        public virtual bool IsValidMove(int targetRow, int targetCol)
        {
            return false;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetCol()
        {
            return col;
        }

        public Type GetPieceType()
        {
            return type;
        }

        public EChessSide GetSide()
        {
            return side;
        }

        public void MoveTo(int row, int col)
        {
            board.SetBoardPiece(this.row, this.col, null);
            this.row = row;
            this.col = col;
            board.SetBoardPiece(this.row, this.col, this);
        }

    }

    
}
