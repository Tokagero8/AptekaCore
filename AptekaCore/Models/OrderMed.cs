using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class OrderMed
    {
        public int OrderMedId { get; set; }
        public int MedicinesId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public virtual Medicines Medicines { get; set; }
        public virtual Order Order { get; set; }
    }
}
