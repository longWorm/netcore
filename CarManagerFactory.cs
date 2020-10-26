using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore
{
    class CarManagerFactory
    {
        static public ICarManager CreateCarManager(bool filesystem)
        {
            if (filesystem)
                return new CarListFileManager();
            else
                return new CarListDBManager();
        }
    }
}
