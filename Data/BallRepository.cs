using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /* public class BallRepository
    {
        private List<Ball> _balls = new List<Ball>();
        public void Add(Ball ball) { _balls.Add(ball); } // usuwanie nie potrzebne, bo będziemy dodawać tylko poprawne kule
        public List<Ball> GetBalls { get {  return _balls; } }
    } */

    // TESTUJĘ
    internal class BallRepository : DataAbstractAPI
    {
        private List<Ball> _balls = new List<Ball>();

        public override void Connect() { throw new NotImplementedException(); }

        public override void Add(Ball ball) { _balls.Add(ball); }

        public override List<Ball> GetBalls() { return _balls; }

        public override void ClearBalls() { _balls.Clear(); }
    }
}
