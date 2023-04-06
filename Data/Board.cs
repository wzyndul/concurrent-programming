using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Board : DataAbstractAPI
    {
        public double BoardWidth { get; set; }
        public double BoardHeight { get; set; }
        public Board(double boardWidth, double boardHeight) {
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
        }

        private List<Ball> _balls = new List<Ball>();

        public override void Connect() { throw new NotImplementedException(); }

        public override void AddBall(Ball ball) { _balls.Add(ball); }

        public override List<Ball> GetBalls() { return _balls; }

        public override void ClearBoard() { _balls.Clear(); }
    }
}
