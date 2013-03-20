using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChargeTower
{
    public class Phone:ListenerObject,IListener
    {

        public double Power { get; set; }
        public Phone()
        {
            Power = 100;
        }
        public void Update(double power)
        {
            Power += power; 
        }

    }
}
