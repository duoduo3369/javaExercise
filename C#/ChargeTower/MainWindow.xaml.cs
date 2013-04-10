using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using System.Reflection;

namespace ChargeTower
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ControlTower controlTower;
        private bool started = false;
        public MainWindow()
        {
            InitializeComponent();
            List<Tower> towers = new List<Tower>();
            List<Phone> phones = new List<Phone>();
            List<ARenderObject> renderTowers = new List<ARenderObject>();
            List<ARenderObject> renderPhones = new List<ARenderObject>();

            towers.Add(new Tower(12));
            towers.Add(new Tower(15));
            towers.Add(new Tower(55));
            towers.Add(new Tower(55));
            towers.Add(new Tower(55));

            phones.Add(new Phone());
            phones.Add(new Phone());
            phones.Add(new Phone());

            phones.ElementAt(0).AddSubject(towers.ElementAt(0));
            foreach (Tower t in towers)
            {
                renderTowers.Add(new RenderTower(t, Carrier));
            }
            foreach (Phone p in phones)
            {
                renderPhones.Add(new RenderPhone(p, Carrier));
            }
            foreach (ARenderObject renderPhone in renderPhones)
            { 
                RenderPhone rp = (RenderPhone)renderPhone;
                rp = new RenderLabelPhone(rp);
            }
            renderTowers.ElementAt(0).SetLocation(200, 20);
            renderTowers.ElementAt(1).SetLocation(20, 120);
            renderTowers.ElementAt(2).SetLocation(145, 205);
            renderTowers.ElementAt(3).SetLocation(30, 407);
            renderTowers.ElementAt(4).SetLocation(160, 500);
            renderPhones.ElementAt(0).SetLocation(19, 44);
            renderPhones.ElementAt(1).SetLocation(69, 224);
            renderPhones.ElementAt(2).SetLocation(269, 324);

            controlTower = new ControlTower(renderTowers, renderPhones);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (started)
            {
                controlTower.Stop();
                ControlButton.Content = "开始运动";
            }
            else
            {
                controlTower.Start();
                ControlButton.Content = "停止运动";
            }
            started = !started;
        }
    }
}
