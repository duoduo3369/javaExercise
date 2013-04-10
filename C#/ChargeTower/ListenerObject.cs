using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ChargeTower
{
    public abstract class ListenerObject
    {

        private List<ISubject> subjectList = new List<ISubject>();
        public void AddSubject(ISubject s)
        {
            if (!IsSubjectListened(s))
            {
                subjectList.Add(s);
            }
        }
        public void RemoveSubject(ISubject s)
        {
            if (IsSubjectListened(s))
            {
                subjectList.Remove(s);
            }
        }
        private bool IsSubjectListened(ISubject s)
        {
            return subjectList.Contains(s);
        }
        public bool IsSubjectEmpty()
        {
            return (subjectList.Count == 0);
        }
    }
}
