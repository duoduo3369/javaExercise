using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargeTower
{
    public interface IListener
    {
        void Update(double power);
    }
}
