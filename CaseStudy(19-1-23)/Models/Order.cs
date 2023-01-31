using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class Order
    {
        [Key]
        public int OId { get; set; }

        public int PId { get; set; }

        
        public string OUName { get; set; }

        public string payment { get; set; }

        public string OrAdress { get; set; }

        public DateTime dateTime { get; set; }
    }
}