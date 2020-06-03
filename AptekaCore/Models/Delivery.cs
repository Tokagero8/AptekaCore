using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            Order = new HashSet<Order>();
        }

        public int DeliveryId { get; set; }
        public string DeliveryMethod { get; set; }
        public string DeliveryTrackNumber { get; set; }
        public string DeliveryStatus { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
