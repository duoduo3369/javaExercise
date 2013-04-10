using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ChargeTower
{
    public class RenderLabelPhone :RenderPhone
    {
        private RenderPhone renderPhone;
        private Label label;
        public RenderLabelPhone(RenderPhone renderPhone)
        {
            label = new Label();
            this.renderPhone = renderPhone;
            SetLocation(-100, -100);
            renderPhone.Canvas.Children.Add(label);
            renderPhone.Timer.Tick += Move;
            UpdateLabel();
        }
        public void moveWithRenderPhone()
        {
            SetLocation(renderPhone.Top, renderPhone.Left);
        }
        public new void SetLocation(double top, double left)
        {
            base.SetLocation(top, left);
            Canvas.SetTop(label, top);
            Canvas.SetLeft(label, left);
        }
        public new void Move(object sender, EventArgs e)
        {
            moveWithRenderPhone();
            UpdateLabel();

        }
        public void UpdateLabel()
        { 
            label.Content = ((Phone)(renderPhone.RenderObject)).Power;
        }
    }
}
