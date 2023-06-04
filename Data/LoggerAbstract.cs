using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class LoggerAbstract
    {
        public abstract void AddBallToSave(IDataBall ball);
        public abstract void AddBoardToSave(DataAbstractAPI board);

        public static LoggerAbstract CreateLogger()
        {
            return new Logger();
        }
    }
}
