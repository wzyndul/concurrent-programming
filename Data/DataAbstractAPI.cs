using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateAPI()
        {
            return new DataAPI();
        }

        public abstract void Connect();
    }
}
