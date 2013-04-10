using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
namespace ChargeTower
{
    public class RenderTower:ARenderObject
    {
        public RenderTower()
        {
            init();
        }
        public RenderTower(Object o,Canvas c)
        {
            init();
            RenderObject = o;
            Canvas = c;
            Canvas.Children.Add(Shape);
        }
        protected override void init()
        {
            if (Shape == null)
            {
                Rectangle r = new Rectangle();
                r.Style = (Style)(Application.Current.TryFindResource("TowerStyle"));
                Shape = r;
            }
        }
        public override void Render()
        {
        }
    }
}
