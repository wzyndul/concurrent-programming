using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class LoggerAbstract
    {
        public abstract void AddLogToSave(IDataBall ball);

        public static LoggerAbstract CreateLogger()
        {
            return new Logger();
        }
    }
}
