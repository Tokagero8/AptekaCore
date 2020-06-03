using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class Vendors
    {
        public Vendors()
        {
            Medicines = new HashSet<Medicines>();
        }

        public int VendId { get; set; }
        public string VendName { get; set; }
        public string VendAdress { get; set; }
        public int VendPhone { get; set; }

        public virtual ICollection<Medicines> Medicines { get; set; }
    }
}
