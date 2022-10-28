using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public enum PieceColor { Black, White };
    public class Piece
    {
        protected Image _image;
        protected PieceColor _color;
        protected Square _square;
        protected int _kind;
        protected Queue<XY> _canEat;
        protected Queue<XY> _canMove;
        protected int _black;
        public Square Square { get { return _square; } }

        public Queue<XY> CanEat
        {
            get { return _canEat; }
            set { _canEat = value; }
        }

        public int Kind
        {
            get { return _kind; }
        }

        public Queue<XY> CanMove
        {
            get { return _canMove; }
            set { _canMove = value; }
        }

        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
            }
        }

        public PieceColor Color
        {
            get { return _color; }
            set
            {
                _color = value;
            }
        }

        public Piece(Square sq, PieceColor color)
        {
            _square = sq;
            _color = color;
            if (color == PieceColor.Black)
                _black = 1;
            else
                _black = -1;
        }

        public virtual void CreateCan(Board b, Square sq)
        {

        }

    }
    public class King : Piece
    {
        public King(Square sq, PieceColor color) : base(sq, color)
        {
            if (color == PieceColor.White)
                _image = Resource.IMAGE_KING_WHITE;
            else
                _image = Resource.IMAGE_KING_BLACK;
            _kind = 0;
        }

        public override void CreateCan(Board b, Square sq)
        {
            int x = sq.SLocation.x;
            int y = sq.SLocation.y;
            _canMove = new Queue<XY>();
            _canEat = new Queue<XY>();

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((x + j * _black < 8 && y + i * _black < 8)
                       && (x + j * _black >= 0 && y + i * _black >= 0))
                    {
                        Piece p = b.Sqs[y + i * _black, x + j * _black].Piece;
                        if (p != null)
                        {
                            if (p.Color != this.Color)
                            {
                                XY temp;
                                temp.x = j * _black;
                                temp.y = i * _black;
                                _canMove.Enqueue(temp);
                                _canEat.Enqueue(temp);
                            }
                        }
                        else
                        {
                            XY temp;
                            temp.x = j * _black;
                            temp.y = i * _black;
                            _canMove.Enqueue(temp);
                        }
                    }
                }
            }
            //if (y + 1 * _black < 8 && y + 1 * _black >= 0)
            //{
            //    if (b.Sqs[y + 1 * _black, x].Piece != null)
            //    {
            //        if (b.Sqs[y + 1 * _black, x].Piece.Color != this.Color)
            //        {
            //            XY temp;
            //            temp.x = 0;
            //            temp.y = 1 * _black;
            //            _canMove.Enqueue(temp);
            //            Console.WriteLine(b.Sqs[y + 1 * _black, x].Color + " " + this.Color);
            //            _canEat.Enqueue(temp);
            //            _canMove.Enqueue(temp);
            //        }
            //    }
            //    else
            //    {
            //        XY temp;
            //        temp.x = 0;
            //        temp.y = 1 * _black;
            //        _canMove.Enqueue(temp);
            //    }
            //}
            //if (y - 1 * _black < 8 && y - 1 * _black >= 0)
            //{
            //    if (b.Sqs[y - 1 * _black, x].Piece != null)
            //    {
            //        if (b.Sqs[y - 1 * _black, x].Piece.Color != this.Color)
            //        {
            //            XY temp;
            //            temp.x = 0;
            //            temp.y = -1 * _black;
            //            _canMove.Enqueue(temp);
            //            Console.WriteLine(b.Sqs[y - 1 * _black, x].Color + " " + this.Color);
            //            _canEat.Enqueue(temp);
            //            _canMove.Enqueue(temp);
            //        }
            //    }
            //    else
            //    {
            //        XY temp;
            //        temp.x = 0;
            //        temp.y = -1 * _black;
            //        _canMove.Enqueue(temp);
            //    }
            //}

            //if (x + 1 * _black < 8 && x + 1 * _black >= 0)
            //{
            //    if (b.Sqs[y, x + 1 * _black].Piece != null)
            //    {
            //        if (b.Sqs[y, x + 1 * _black].Piece.Color != this.Color)
            //        {
            //            XY temp;
            //            temp.x = 1 * _black;
            //            temp.y = 0;
            //            _canMove.Enqueue(temp);
            //            Console.WriteLine(b.Sqs[y, x + 1 * _black].Color + " " + this.Color);
            //            _canEat.Enqueue(temp);
            //            _canMove.Enqueue(temp);
            //        }
            //    }
            //    else
            //    {
            //        XY temp;
            //        temp.x = 1 * _black;
            //        temp.y = 0;
            //        _canMove.Enqueue(temp);
            //    }
            //}
            //if (x - 1 * _black < 8 && x - 1 * _black >= 0)
            //{
            //    if (b.Sqs[y, x - 1 * _black].Piece != null)
            //    {
            //        if (b.Sqs[y, x - 1 * _black].Piece.Color != this.Color)
            //        {
            //            XY temp;
            //            temp.x = -1 * _black;
            //            temp.y = 0;
            //            _canMove.Enqueue(temp);
            //            Console.WriteLine(b.Sqs[y, x - 1 * _black].Color + " " + this.Color);
            //            _canEat.Enqueue(temp);
            //            _canMove.Enqueue(temp);
            //        }
            //    }
            //    else
            //    {
            //        XY temp;
            //        temp.x = -1 * _black;
            //        temp.y = 0;
            //        _canMove.Enqueue(temp);
            //    }
            //}
        }
    }

    public class Pawn : Piece
    {
        private Boolean _firstMove;
        public Boolean FirstMove
        {
            get { return _firstMove; }
            set 
            { 
                _firstMove = value; 
                if (_firstMove == true)
                {
                    CanMove.Dequeue();
                }    
            }
        }
        public Pawn(Square sq, PieceColor color) : base(sq, color)
        {
            _kind = 1;
            _firstMove = false;

            if (color == PieceColor.White)
                _image = Resource.IMAGE_PAWN_WHITE;
            else
                _image = Resource.IMAGE_PAWN_BLACK;

        }

        public override void CreateCan(Board b, Square sq)
        {
            int x = sq.SLocation.x;
            int y = sq.SLocation.y;
            _canMove = new Queue<XY>();
            _canEat = new Queue<XY>();

            if (y + 1 * _black >= 0 && y + 1 *_black < 8)
            {
                Piece p = b.Sqs[y + 1 * _black, x].Piece;
                if (p == null)
                {
                    XY temp;
                    temp.x = 0;
                    temp.y = 1 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if (y + 2 * _black >= 0 && y + 2 * _black < 8 && !_firstMove)
            {
                Piece p = b.Sqs[y + 2 * _black, x].Piece;
                if (p == null)
                {
                    if (b.Sqs[y + 1 * _black, x].Piece == null)
                    {
                        XY temp;
                        temp.x = 0;
                        temp.y = 2 * _black;
                        _canMove.Enqueue(temp);
                    }
                }
            }

            if (y + 1 * _black >= 0 && y + 1 * _black < 8
                && x + 1 * _black >= 0 && x + 1 * _black < 8)
            {
                Piece p = b.Sqs[y + 1 * _black, x + 1 * _black].Piece;
                if (p != null)
                {
                    XY temp;
                    temp.x = 1 * _black;
                    temp.y = 1 * _black;
                    _canEat.Enqueue(temp);
                }
            }

            if (y + 1 * _black >= 0 && y + 1 * _black < 8
                && x - 1 * _black >= 0 && x - 1 * _black < 8)
            {
                Piece p = b.Sqs[y + 1 * _black, x - 1 * _black].Piece;
                if (p != null)
                {
                    XY temp;
                    temp.x = -1 * _black;
                    temp.y = 1 * _black;
                    _canEat.Enqueue(temp);
                }
            }
        }
    }

    public class Queen : Piece
    {
        public Queen(Square sq, PieceColor color) : base(sq, color)
        {
            _kind = 2;
            if (color == PieceColor.White)
                _image = Resource.IMAGE_QUEEN_WHITE;
            else
                _image = Resource.IMAGE_QUEEN_BLACK;
        }

        public override void CreateCan(Board b, Square sq)
        {
            int x = sq.SLocation.x;
            int y = sq.SLocation.y;
            _canMove = new Queue<XY>();
            _canEat = new Queue<XY>();

            int i = 1;
            while ((x + i * _black < 8 && y + i * _black < 8 && _black == 1)
                || (x + i * _black >= 0 && y + i * _black >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + i * _black, x + i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = i * _black;
                        temp.y = i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = i * _black;
                    temp.y = i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((x + i * _black < 8 && y - i * _black >= 0 && _black == 1)
                || (x + i * _black >= 0 && y - i * _black < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - i * _black, x + i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = i * _black;
                        temp.y = -i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = i * _black;
                    temp.y = -i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((x - i * _black >= 0 && y + i * _black < 8 && _black == 1)
                || (x - i * _black < 8 && y + i * _black >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + i * _black, x - i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -i * _black;
                        temp.y = i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = -i * _black;
                    temp.y = i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((x - i * _black >= 0 && y - i * _black >= 0 && _black == 1)
                || (x - i * _black < 8 && y - i * _black < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - i * _black, x - i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -i * _black;
                        temp.y = -i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = -i * _black;
                    temp.y = -i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((i * _black + x < 8 && _black == 1) || (i * _black + x >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y, x + i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = i * _black;
                        temp.y = 0;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = i * _black;
                    temp.y = 0;
                    _canMove.Enqueue(temp);

                }
                i++;
            }

            i = 1;
            while ((x - i * _black >= 0 && _black == 1) || (x - i * _black < 8 && _black == -1))
            {
                Piece p = b.Sqs[y, x - i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -i * _black;
                        temp.y = 0;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = -i * _black;
                    temp.y = 0;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((y + i * _black < 8 && _black == 1) || (y + i * _black >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + i * _black, x].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 0;
                        temp.y = i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }

                {
                    XY temp;
                    temp.x = 0;
                    temp.y = i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((y - i * _black < 8 && _black == -1) || (y - i * _black >= 0 && _black == 1))
            {
                Piece p = b.Sqs[y - i * _black, x].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 0;
                        temp.y = -i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = 0;
                    temp.y = -i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }
        }
    }

    public class Rook : Piece
    {
        public Rook(Square sq, PieceColor color) : base(sq, color)
        {
            _kind = 3;
            if (color == PieceColor.White)
                _image = Resource.IMAGE_ROOK_WHITE;
            else
                _image = Resource.IMAGE_ROOK_BLACK;
        }

        public override void CreateCan(Board b, Square sq)
        {
            int x = sq.SLocation.x;
            int y = sq.SLocation.y;
            _canMove = new Queue<XY>();
            _canEat = new Queue<XY>();

            int i = 1;
            while ((i * _black + x < 8 && _black == 1) || (i * _black + x >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y, x + i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = i * _black;
                        temp.y = 0;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = i * _black;
                    temp.y = 0;
                    _canMove.Enqueue(temp);

                }
                i++;
            }

            i = 1;
            while ((x - i * _black >= 0 && _black == 1) || (x - i * _black < 8 && _black == -1))
            {
                Piece p = b.Sqs[y, x - i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -i * _black;
                        temp.y = 0;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = -i * _black;
                    temp.y = 0;
                    _canMove.Enqueue(temp);
                }              
                i++;
            }

            i = 1;
            while ((y + i * _black < 8 && _black == 1) || (y + i * _black >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + i * _black, x].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 0;
                        temp.y = i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }

                {
                    XY temp;
                    temp.x = 0;
                    temp.y = i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((y - i * _black < 8 && _black == -1) || (y - i * _black >= 0 && _black == 1))
            {
                Piece p = b.Sqs[y - i * _black, x].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 0;
                        temp.y = -i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = 0;
                    temp.y = -i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

        }
    }

    public class Knight : Piece
    {
        public Knight(Square sq, PieceColor color) : base(sq, color)
        {
            _kind = 4;
            if (color == PieceColor.White)
                _image = Resource.IMAGE_KNIGHT_WHITE;
            else
                _image = Resource.IMAGE_KNIGHT_BLACK;
        }

        public override void CreateCan(Board b, Square sq)
        {
            int x = sq.SLocation.x;
            int y = sq.SLocation.y;
            _canMove = new Queue<XY>();
            _canEat = new Queue<XY>();

            if ((x - 2 >= 0 && y - 1 >= 0 && _black == 1) || (x + 2 < 8 && y + 1 < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - 1 * _black, x - 2 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -2 * _black;
                        temp.y = -1 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = -2 * _black;
                    temp.y = -1 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if ((x - 1 >= 0 && y - 2 >= 0 && _black == 1) || (x + 1 < 8 && y + 2 < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - 2 * _black, x - 1 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -1 * _black;
                        temp.y = -2 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = -1 * _black;
                    temp.y = -2 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if ((x + 2 < 8 && y - 1 >= 0 && _black == 1) || (x - 2 >= 0 && y + 1 < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - 1 * _black, x + 2 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 2 * _black;
                        temp.y = -1 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = 2 * _black;
                    temp.y = -1 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if ((x + 1 < 8 && y - 2 >= 0 && _black == 1) || (x - 1 >= 0 && y + 2 < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - 2 * _black, x + 1 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 1 * _black;
                        temp.y = -2 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = 1 * _black;
                    temp.y = -2 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if ((x - 2 >= 0 && y + 1 < 8 && _black == 1) || (x + 2 < 8 && y - 1 >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + 1 * _black, x - 2 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -2 * _black;
                        temp.y = 1 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = -2 * _black;
                    temp.y = 1 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if ((x - 1 >= 0 && y + 2 < 8 && _black == 1) || (x + 1 < 8 && y - 2 >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + 2 * _black, x - 1 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -1 * _black;
                        temp.y = 2 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = -1 * _black;
                    temp.y = 2 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if ((x + 1 < 8 && y + 2 < 8 && _black == 1) || (x - 1 >= 0 && y - 2 >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + 2 * _black, x + 1 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 1 * _black;
                        temp.y = 2 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = 1 * _black;
                    temp.y = 2 * _black;
                    _canMove.Enqueue(temp);
                }
            }

            if ((x + 2 < 8 && y + 1 < 8 && _black == 1) || (x - 2 >= 0 && y - 1 >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + 1 * _black, x + 2 * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = 2 * _black;
                        temp.y = 1 * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                    }
                }
                else
                {
                    XY temp;
                    temp.x = 2 * _black;
                    temp.y = 1 * _black;
                    _canMove.Enqueue(temp);
                }
            }

        }
    }

    public class Bishop : Piece
    {
        public Bishop(Square sq, PieceColor color) : base(sq, color)
        {
            _kind = 5;
            if (color == PieceColor.White)
                _image = Resource.IMAGE_BISHOP_WHITE;
            else
                _image = Resource.IMAGE_BISHOP_BLACK;

        }

        public override void CreateCan(Board b, Square sq)
        {
            int x = sq.SLocation.x;
            int y = sq.SLocation.y;
            _canMove = new Queue<XY>();
            _canEat = new Queue<XY>();

            int i = 1;
            while ((x + i * _black < 8 && y + i * _black < 8 && _black == 1)
                || (x + i * _black >= 0 && y + i * _black >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + i * _black, x + i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = i * _black;
                        temp.y = i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = i * _black;
                    temp.y = i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((x + i * _black < 8 && y - i * _black >= 0 && _black == 1)
                || (x + i * _black >= 0 && y - i * _black < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - i * _black, x + i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = i * _black;
                        temp.y = -i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = i * _black;
                    temp.y = -i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((x - i * _black >= 0 && y + i * _black < 8 && _black == 1)
                || (x - i * _black < 8 && y + i * _black >= 0 && _black == -1))
            {
                Piece p = b.Sqs[y + i * _black, x - i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -i * _black;
                        temp.y = i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = -i * _black;
                    temp.y = i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

            i = 1;
            while ((x - i * _black >= 0 && y - i * _black >= 0 && _black == 1)
                || (x - i * _black < 8 && y - i * _black < 8 && _black == -1))
            {
                Piece p = b.Sqs[y - i * _black, x - i * _black].Piece;
                if (p != null)
                {
                    if (p.Color != this.Color)
                    {
                        XY temp;
                        temp.x = -i * _black;
                        temp.y = -i * _black;
                        _canMove.Enqueue(temp);
                        _canEat.Enqueue(temp);
                        break;
                    }
                    else
                        break;
                }
                {
                    XY temp;
                    temp.x = -i * _black;
                    temp.y = -i * _black;
                    _canMove.Enqueue(temp);
                }
                i++;
            }

        }

    }
}
