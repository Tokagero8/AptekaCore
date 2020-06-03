using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class Medicines
    {
        public Medicines()
        {
            OrderMed = new HashSet<OrderMed>();
        }

        public int MedId { get; set; }
        public string MedName { get; set; }
        public int MedInt { get; set; }
        public string MedDesc { get; set; }
        public decimal MedPrice { get; set; }
        public int VendorsId { get; set; }
        public string MedCat { get; set; }
        public int MedQuant { get; set; }
        public bool MedReceipt { get; set; }

        public virtual Vendors Vendors { get; set; }
        public virtual ICollection<OrderMed> OrderMed { get; set; }
    }
}
