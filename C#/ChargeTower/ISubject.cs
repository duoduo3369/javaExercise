using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargeTower
{
    public interface ISubject
    {
        void AddListener(IListener i);
        void RemoveListener(IListener i);
        void NotifyAll();
    }
}
