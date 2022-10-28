using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{

    public class Board
    {
        protected Square[,] sqs;
        private int _squareWidth = 64;
        private int _squareHeight = 64;
        private PieceColor _turnColor;

        public PieceColor TurnColor
        {
            get { return _turnColor; }
            set { _turnColor = value; }
        }

        public Form ParentForm { get; set; }
        private SquareColor c = SquareColor.White;

        public Square[,] Sqs
        {
            get { return sqs; }
        }

        public Board(Form parent, int width = 64, int height = 64)
        {
            sqs = new Square[8, 8];
            _squareWidth = width;
            _squareHeight = height;
            ParentForm = parent;
            _init();
        }
        public void _init()
        {
            TurnColor = PieceColor.White;
            int top = 0;
            for (int i = 0; i < 8; i++)
            {
                int left = 0;
                for (int j = 0; j < 8; j++)
                {

                    Square sq = new Square(c, this, j, i);
                    sq.Width = _squareWidth;
                    sq.Height = _squareHeight;
                    //sq.Left = left;
                    //sq.Top = top;
                    sq.Location = new Point(left, top);
                    left += _squareWidth;
                    sqs[i, j] = sq;
                    ParentForm.Controls.Add(sq);
                    if (c == SquareColor.White)
                        c = SquareColor.Black;
                    else
                        c = SquareColor.White;
                }
                top += _squareHeight;
                if (c == SquareColor.White)
                    c = SquareColor.Black;
                else
                    c = SquareColor.White;

            }
            // Place initial pieces


            // BLACK
            // ROOK
            this[0, 0] = new Rook(sqs[0, 0], PieceColor.Black);
            this[0, 7] = new Rook(sqs[0, 7], PieceColor.Black);

            //KNIGHT
            this[0, 1] = new Knight(sqs[0, 1], PieceColor.Black);
            this[0, 6] = new Knight(sqs[0, 6], PieceColor.Black);

            //BISHOP
            this[0, 2] = new Bishop(sqs[0, 2], PieceColor.Black);
            this[0, 5] = new Bishop(sqs[0, 5], PieceColor.Black);

            this[0, 3] = new Queen(sqs[0, 3], PieceColor.Black);
            this[0, 4] = new King(sqs[0, 4], PieceColor.Black);



            for (int i = 0; i < 8; i++)
            {
                this[1, i] = new Pawn(sqs[1, i], PieceColor.Black);
            }

            // ROOK
            this[7, 0] = new Rook(sqs[7, 0], PieceColor.White);
            this[7, 7] = new Rook(sqs[7, 7], PieceColor.White);

            //KNIGHT
            this[7, 1] = new Knight(sqs[7, 1], PieceColor.White);
            this[7, 6] = new Knight(sqs[7, 6], PieceColor.White);

            //BISHOP
            this[7, 2] = new Bishop(sqs[7, 2], PieceColor.White);
            this[7, 5] = new Bishop(sqs[7, 5], PieceColor.White);

            this[7, 3] = new Queen(sqs[7, 3], PieceColor.White);
            this[7, 4] = new King(sqs[7, 4], PieceColor.White);

            for (int i = 0; i < 8; i++)
            {
                this[6, i] = new Pawn(sqs[6, i], PieceColor.White);
            }
        }
        
        

        public Piece this[int i, int j]
        {
            get { return sqs[i, j].Piece; }
            set { sqs[i, j].Piece = value; }
        }

        protected Square _selectedSquare;
        public Square SelectedSquare
        {
            get
            {
                return _selectedSquare;
            }
            set
            {
                if (_selectedSquare != null) _selectedSquare.Selected = false;
                _selectedSquare = value;
            }
        }
    }
}
