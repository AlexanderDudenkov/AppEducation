using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEducation
{
    public class CollectInt : ICollect<int>
    {
        private List<int> collect = new List<int>();

        public void Add(int item)
        {
            collect.Add(item);
        }

        public bool Del(int item)
        {
            return collect.Remove(item);
        }

        public int GetItem(int index)
        {
            return collect[index];
        }

        public ICollect<int> Reverse()
        {
            List<int> revCollect = new List<int>();
            for (int i = 0; i < collect.Count(); i++)
            {
                int index = collect.Count() - 1 - i;
                int item = collect[index];
                revCollect.Add(item);
            }

            collect = revCollect;

            return this;
        }

        public bool SetItem(int index, int item)
        {
            if (index >= 0 && index < collect.Count)
            {
                collect.Insert(index, item);
                return collect[index] == item;
            }
            return false;
        }
    }
}
