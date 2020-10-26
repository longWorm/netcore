using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore
{
    interface ICarManager
    {
        int Load(CarList carList);
        void Save(CarList carList);
    }
}
