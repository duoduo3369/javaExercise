using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace ChargeTower
{
    public class ControlTower:AControlObject,ITimerList
    {
        public ControlTower(List<ARenderObject> towers, List<ARenderObject> phones) :
            base(towers, phones)
        { 
            foreach(ARenderObject p in phones)
            {
                RenderPhone P = (RenderPhone)p;
                List<DispatcherTimer> list = P.GetTimerList();
                foreach(DispatcherTimer timer in list)
                {
                    timerList.Add(timer);
                }
            }
        }
        public ControlTower()
        { 
        }
        private List<DispatcherTimer> timerList;
        private DispatcherTimer chargingTimer;
        public DispatcherTimer ChargingTimer
        {
            get
            {
                return chargingTimer;
            }
            set
            {
                chargingTimer = value;    
            }
        }
        private DispatcherTimer checkTimer;
        public DispatcherTimer CheckTimer
        {
            get
            {
                return checkTimer;
            }
            set
            {
                CheckTimer = value;
            }
        }
        
        public override bool IsReachedChargeArea(ARenderObject tower, ARenderObject phone)
        {
            Rect pRect = new Rect(phone.Left, phone.Top, phone.Width, phone.Height);
            Rect tRect = new Rect(tower.Left - tower.Width, tower.Top - tower.Height, 3 * tower.Width, 3 * tower.Height);
            return pRect.IntersectsWith(tRect);
        }

        public override void Update()
        {
            foreach (ARenderObject t in towers)
            {
                RenderTower tower = (RenderTower)t;
                Tower T = (Tower)tower.RenderObject;
                foreach (ARenderObject p in phones)
                {
                    RenderPhone phone = (RenderPhone)p;
                    Phone P = (Phone)phone.RenderObject;
                    bool isListened = T.IsListenerContained(P);
                    bool isReachedChargeArea = IsReachedChargeArea(tower, phone);
                    if (isReachedChargeArea && !isListened) //进入一个区域
                    {
                        ///*
                        if (P.IsSubjectEmpty())
                        {
                            phone.Shape.Style = RenderPhone.ChargingStyle;
                        }
                        //*/
                        //    phone.Shape.Style = RenderPhone.ChargingStyle;
                        T.AddListener(P);
                        P.AddSubject(T);
                    }
                    else if (!isReachedChargeArea && isListened) //离开一个区域
                    {
                        T.RemoveListener(P);
                        P.RemoveSubject(T);
                        ///*
                        if (P.IsSubjectEmpty())
                        { 
                            phone.Shape.Style = RenderPhone.InitStyle;
                        }
                        //*/
                       //     phone.Shape.Style = RenderPhone.InitStyle;
                    }
                }
            }
        }
        private void checking(object sender, EventArgs e)
        {
            Update();
        }
        private void charging(object sender, EventArgs e)
        {
            foreach (ARenderObject t in towers)
            {
                Tower T = (Tower)t.RenderObject;
                T.NotifyAll();
            }
        }

        public override void init()
        {
            chargingTimer = new DispatcherTimer();
            chargingTimer.Tick += charging;
            chargingTimer.Interval = TimeSpan.FromSeconds(0.2);

            checkTimer = new DispatcherTimer();
            checkTimer.Tick += checking;
            checkTimer.Interval = TimeSpan.FromSeconds(0.5);
            timerList = new List<DispatcherTimer>();
            timerList.Add(chargingTimer);
            timerList.Add(CheckTimer);
        }

        public void Start()
        {
            foreach (DispatcherTimer timer in timerList)
            {
                timer.Start();
            }
        }
        public void Stop()
        {
            foreach (DispatcherTimer timer in timerList)
            {
                timer.Stop();
            }
        }
        public List<DispatcherTimer> GetTimerList()
        {
            return timerList;
        }
    }
}
