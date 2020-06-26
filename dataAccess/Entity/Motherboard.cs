using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess.Entity
{
    public class Motherboard
    {
        //chipsetname,name,socketname
        public int moboId { get; set; }
        public int pcPartID { get; set; }
        public string chipsetName { get; set; }
        public string name { get; set; }
        public string socketName { get; set; }
    }
}
