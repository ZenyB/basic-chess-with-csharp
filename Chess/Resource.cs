using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    public class Resource
    {
        public static Image IMAGE_PAWN_BLACK = Image.FromFile("images\\pawn_black.png");
        public static Image IMAGE_ROOK_BLACK = Image.FromFile("images\\rook_black.png");
        public static Image IMAGE_KNIGHT_BLACK = Image.FromFile("images\\knight_black.png");
        public static Image IMAGE_BISHOP_BLACK = Image.FromFile("images\\bishop_black.png");
        public static Image IMAGE_QUEEN_BLACK = Image.FromFile("images\\queen_black.png");
        public static Image IMAGE_KING_BLACK = Image.FromFile("images\\king_black.png");

        public static Image IMAGE_PAWN_WHITE = Image.FromFile("images\\pawn_white.png");
        public static Image IMAGE_ROOK_WHITE = Image.FromFile("images\\rook_white.png");
        public static Image IMAGE_KNIGHT_WHITE = Image.FromFile("images\\knight_white.png");
        public static Image IMAGE_BISHOP_WHITE = Image.FromFile("images\\bishop_white.png");
        public static Image IMAGE_QUEEN_WHITE = Image.FromFile("images\\queen_white.png");
        public static Image IMAGE_KING_WHITE = Image.FromFile("images\\king_white.png");
    }
}
