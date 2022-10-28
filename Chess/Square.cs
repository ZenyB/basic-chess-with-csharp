using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    public struct XY
    {
        public int x;
        public int y;
    }
    public enum SquareColor { White, Black };
    public class Square : PictureBox
    {
        protected SquareColor _color;
        protected Board _board;
        protected Piece _piece;
        protected XY _slocation;
        protected Boolean _selected;
        protected bool _canMove;
        protected bool _canEat;

        public Board Board
        {
            get { return _board; }
        }

        public XY SLocation
        {
            get { return _slocation; }
            set { _slocation = value; }
        }

        static void OnMouseClick(object sender, MouseEventArgs e)
        {
            Square sq = (Square)sender;

            if (e.Button == MouseButtons.Left)
            {
                if (sq.Piece == null)
                    return;
                if (sq.Piece.Color != sq._board.TurnColor)
                    return;
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (sq._board.Sqs[i, j].CanMove)
                            sq._board.Sqs[i, j].CanMove = false;
                        if (sq._board.Sqs[i, j].CanEat)
                        {
                            sq._board.Sqs[i, j].CanEat = false;
                            sq._board.Sqs[i, j].CanMove = false;
                        }

                    }

                if (sq.Piece == null)
                    return;
                sq.Selected = true;

                sq.Piece.CreateCan(sq.Board, sq);
                Console.WriteLine(sq.SLocation.x + " " + sq.SLocation.y);

                foreach (XY canmove in sq.Piece.CanMove)
                {
                    int tempx = sq.SLocation.x + canmove.x;
                    int tempy = sq.SLocation.y + canmove.y;
                    sq.Board.Sqs[tempy, tempx].CanMove = true;
                }

                foreach (XY caneat in sq.Piece.CanEat)
                {
                    int tempx = sq.SLocation.x + caneat.x;
                    int tempy = sq.SLocation.y + caneat.y;
                    sq.Board.Sqs[tempy, tempx].CanMove = true;
                    sq.Board.Sqs[tempy, tempx].CanEat = true;
                }

            }
            else if (e.Button == MouseButtons.Right)
            {
                Board b = sq._board;
                if (b.SelectedSquare == null)
                    return;

                if (b.SelectedSquare.Piece.Kind == 1)
                {
                    Pawn temp = (Pawn)b.SelectedSquare.Piece;
                    if (temp.FirstMove == false)
                        temp.FirstMove = true;
                }

                if (sq.CanMove == false)
                    return;
                if (sq.Piece != null && sq.Piece.Kind == 0)
                {
                    if (sq.Piece.Color == PieceColor.Black)
                        MessageBox.Show("White Win");
                    else
                        MessageBox.Show("Black Win");
                    sq._board.ParentForm.Close();
                }

                sq.Piece = b.SelectedSquare.Piece;
                b.SelectedSquare.Piece = null;
                sq.Selected = true;

                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        sq._board.Sqs[i, j].CanMove = false;
                        sq._board.Sqs[i, j].CanEat = false;
                    }
                if (sq._board.TurnColor == PieceColor.White)
                    sq._board.TurnColor = PieceColor.Black;
                else
                    sq._board.TurnColor = PieceColor.White;
            }
        }

        public Piece Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                if (_piece != null)
                    Image = value.Image;
                else
                    Image = null;
            }
        }

        public SquareColor Color
        {
            get { return _color; }
            set
            {
                _color = value;
                if (_color == SquareColor.White)
                    this.BackColor = System.Drawing.Color.White;
                else
                    this.BackColor = System.Drawing.Color.Gray;
            }
        }

        public Boolean Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;

                if (value == true)
                {
                    _board.SelectedSquare = this;
                    BackColor = System.Drawing.Color.LightBlue;
                }
                else
                    Color = _color;
            }
        }

        public bool CanMove
        {
            get { return _canMove; }
            set 
            { 
                _canMove = value;
                if (_canMove)
                    this.BackColor = System.Drawing.Color.Bisque;
                else
                {
                    if ((this.SLocation.x + this.SLocation.y) % 2 == 0)
                        this.Color = SquareColor.White;
                    else
                        this.Color = SquareColor.Black;
                }
                    

            }
        }

        public bool CanEat
        {
            get { return _canEat; }
            set
            {
                _canEat = value;
                if (_canEat)
                    this.BackColor = System.Drawing.Color.OrangeRed;
                else
                {
                    if ((this.SLocation.x + this.SLocation.y) % 2 == 0)
                        this.Color = SquareColor.White;
                    else
                        this.Color = SquareColor.Black;
                }
            }
        }

        public Square(SquareColor s, Board b, int x, int y, Piece p = null)
        {
            Color = s;
            _piece = p;
            _board = b;
            SizeMode = PictureBoxSizeMode.StretchImage;
            _slocation.x = x;
            _slocation.y = y;
            _canMove = false;

            this.MouseClick += new MouseEventHandler(OnMouseClick);
        }


    }
}
