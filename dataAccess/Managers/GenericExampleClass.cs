using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess.Managers
{
    public class GenericExampleClass<T> where T: new()
    {
        public T Add(T model)
        {
            return model;
        }
        public bool Update(T model)
        {
            return true;
        }
        public bool Delete(T model)
        {
            return true;
        }
        public T Get(int id)
        {
            return new T();
        }
        public List<T> GetList(int id)
        {
            return new List<T>();
        }

    }
}
