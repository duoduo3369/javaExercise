using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace ChargeTower
{
    public abstract class AControlObject
    {
        protected List<ARenderObject> towers;
        protected List<ARenderObject> phones;
        public AControlObject()
        {
            init();
        }
        public AControlObject(List<ARenderObject> towers, List<ARenderObject> phones)
        {
            this.towers = towers;
            this.phones = phones;
            init();
        }
        public abstract bool IsReachedChargeArea(ARenderObject tower,ARenderObject phone);
        public abstract void Update();
        public abstract void init();
    }
}
