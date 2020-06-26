using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess.Entity
{
    public class Cpu
    {
        public int cpuid { get; set; }
        public int pcPartID { get; set; }
        public string Name { get; set; }
        public int cachesize { get; set; }
        public int nanometer { get; set; }
        public float speed { get; set; }

    }
}
