using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace ChargeTower
{
    public interface ITimerList
    {
        List<DispatcherTimer> GetTimerList();
    }
}
