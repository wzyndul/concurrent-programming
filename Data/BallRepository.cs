﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallRepository
    {
        private List<Ball> balls = new List<Ball>();
        public void Add(Ball ball) { balls.Add(ball); } // usuwanie nie potrzebne, bo będziemy dodawać tylko poprawne kule
        public List<Ball> GetBalls { get {  return balls; } }
    }
}
