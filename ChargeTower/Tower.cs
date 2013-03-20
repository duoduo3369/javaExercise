using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChargeTower
{
    public class Tower:ISubject
    {
        public double Power { get;private set; }
        private List<IListener> listenerList = new List<IListener>();

        public Tower(double power)
        {
            Power = power;
           
        }

        public void AddListener(IListener i)
        {
            if(!IsListenerContained(i))
            {
                listenerList.Add(i);
            }
        }

        public void RemoveListener(IListener i)
        {
            if (IsListenerContained(i))
            {
                listenerList.Remove(i);
            }
        }

        public void NotifyAll()
        {
            foreach(IListener i in listenerList)
            {
                i.Update(Power);
            }
        }
        public bool IsListenerContained(IListener i)
        {
            return listenerList.Contains(i);
        }
        
    }
}
