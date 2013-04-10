using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;

namespace ChargeTower
{
    public class RenderPhone : ARenderObject, ITimerList, IMove
    {
        private DispatcherTimer timer;
        public DispatcherTimer Timer { get { return timer; } }
        private List<DispatcherTimer> timerList;
        public static Style InitStyle =(Style)(Application.Current.TryFindResource("PhoneStyle"));
        public static Style ChargingStyle = (Style)(Application.Current.TryFindResource("PhoneChargingStyle"));
        public double TimeSpen { get; set; }
        public RenderPhone()
        { 
            init();
        }
        public RenderPhone(Object o, Canvas c)
        {
            init();
            RenderObject = o;
            Canvas = c;
            Canvas.Children.Add(Shape);
        }
        public override void Render()
        {
        }

        protected override void init()
        {
            if (Shape == null)
            {
                Rectangle r = new Rectangle();
                r.Style = InitStyle;
                Shape = r;
            }
            timer = new DispatcherTimer();
            TimeSpen = 0.025;
            timer.Tick += Move;
            timer.Interval = TimeSpan.FromSeconds(TimeSpen);

            timerList = new List<DispatcherTimer>();
            timerList.Add(timer);
        }
        public List<DispatcherTimer> GetTimerList()
        {
            return timerList;
        }

        public void Move(object sender, EventArgs e)
        {
            Left += 1;
        }
    }
}
