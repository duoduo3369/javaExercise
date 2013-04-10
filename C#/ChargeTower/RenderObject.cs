using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;

namespace ChargeTower
{
    public abstract class ARenderObject : ILocation
    {
        public Object RenderObject { get;protected set; }
        public Shape Shape { get;protected set; }
        public Canvas Canvas { get; set; }
        public double Width 
        {
            get
            {
                return Shape.Width;
            }
            set
            {
                Shape.Width = value;
            }
        }
        public double Height 
        {
            get
            {
                return Shape.Height;
            }
            set
            {
                Shape.Height = value;
            }

        }

        public ARenderObject(Object o, Shape s,Canvas c)
        {
            RenderObject = o;
            Shape = s;
            Canvas = c;
        }
        public ARenderObject(){}
        public double Top {
            get
            {
                return Canvas.GetTop(Shape);
            }
            set
            {
                SetTop(Shape,value);
            }
        }
        public double Left {
            get
            {
                return Canvas.GetLeft(Shape);
            }
            set
            {
                SetLeft(Shape,value);
            }
        }
        public void SetTop(UIElement e,double d)
        {
            Canvas.SetTop(e, d);
        }
        public void SetLeft(UIElement e, double d)
        {
            Canvas.SetLeft(e, d);
        }
        public void SetLocation(double top, double left)
        {
            SetTop(Shape,top);
            SetLeft(Shape,left);
        }
        public abstract void Render();
        protected abstract void init();
    }
}
