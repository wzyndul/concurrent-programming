using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Board
    {
        public double BoardWidth { get; set; }
        public double BoardHeight { get; set; }
        public Board(double boardWidth, double boardHeight) {
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
        }
    }
}
