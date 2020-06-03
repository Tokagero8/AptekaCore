using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Order = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime? PaymentTime { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
