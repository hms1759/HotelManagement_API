using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class Order 
    {
        [Key]
        public int id { get; set; }
        public string OrderName { get; set; }
        public string Date { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTimeIn { get; set; }
        public string ScheduleTimeOut { get; set; }
        public int  visitorId { get; set; }

    }
}
