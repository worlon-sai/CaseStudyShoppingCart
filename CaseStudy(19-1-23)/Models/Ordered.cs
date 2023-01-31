using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class Ordered
    {
        [Key]
        public int OrId { get; set; }

        public int PId { get; set; }

        public string OrUName { get; set; }

        public string OrAdress { get; set; }

        public DateTime dateTime { get; set; }
    }
}