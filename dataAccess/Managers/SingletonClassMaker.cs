using dataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess.Managers
{
    public class SingletonClassMaker
    {
        public GenericExampleClass<Cpu> cpu = new GenericExampleClass<Cpu>();
        public GenericExampleClass<Motherboard> mobo= new GenericExampleClass<Motherboard>();

        private static SingletonClassMaker _maker = new SingletonClassMaker();
        public static SingletonClassMaker instance = _maker;

       
    }
}
