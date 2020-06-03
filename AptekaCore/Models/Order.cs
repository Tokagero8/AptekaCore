using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderMed = new HashSet<OrderMed>();
        }

        public int OrderId { get; set; }
        public int CustomersId { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? PaymentId { get; set; }
        public int? DeliveryId { get; set; }
        public bool Completed { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderMed> OrderMed { get; set; }
    }
}
