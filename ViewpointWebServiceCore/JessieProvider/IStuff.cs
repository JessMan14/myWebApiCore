using System;
using System.Collections.Generic;
using System.Text;

namespace JessieProvider
{
    public interface IStuff
    {
        public List<T> GetAll<T>();
        public T Get<T>();
        public void Add<T>(T t);
        public void Delete<T>(int id);
    }
}
