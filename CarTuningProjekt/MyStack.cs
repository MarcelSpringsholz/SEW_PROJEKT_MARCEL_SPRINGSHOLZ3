using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTuningProjekt
{
    class MyStack<T>
    {
        List<T> s = new List<T>();
        public void push(T a)
        {
            s.Add(a);
        }
        public object pop()
        {
            T a = s[s.Count - 1];
            s.RemoveAt(s.Count - 1);
            return a;
        }
        public T peek()
        {
            return s[s.Count - 1];
        }
        public void Clear()
        {
            s.Clear();
        }
        public bool Contains(T b)
        {
            for (int i = 0; i < s.Count; i++)
            {
                if (b.Equals(s[i]))
                {
                    return true;
                }
            }
            return false;

        }

    }
}
