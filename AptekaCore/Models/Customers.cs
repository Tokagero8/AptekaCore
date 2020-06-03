using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Order = new HashSet<Order>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustSurname { get; set; }
        public int CustPhone { get; set; }
        public string CustMail { get; set; }
        public string CustLogin { get; set; }
        public string CustPasswd { get; set; }
        public string CustAdress { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
