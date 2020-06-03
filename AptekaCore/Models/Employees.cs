using System;
using System.Collections.Generic;

namespace AptekaCore.Models
{
    public partial class Employees
    {
        public int EmplId { get; set; }
        public string EmplName { get; set; }
        public string EmplSurname { get; set; }
        public int EmplPhone { get; set; }
        public string EmplMail { get; set; }
        public string EmplLogin { get; set; }
        public string EmplPasswd { get; set; }
        public string EmplTitle { get; set; }
        public string EmplHead { get; set; }
    }
}
