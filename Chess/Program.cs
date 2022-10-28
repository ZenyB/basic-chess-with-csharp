using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Form f = new Form();
            f.Size = new Size(100 * 8, 70 * 8);
            Board b = new Board(f, 64, 64);
            Application.Run(f);
        }
    }

}
