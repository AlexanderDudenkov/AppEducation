using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEducation
{
    public interface ICollect<T>
    {
        void Add(T item);
        bool Del(T item);
        T GetItem(int index);
        bool SetItem(int index, T item);
        ICollect<T> Reverse();
    }
}

