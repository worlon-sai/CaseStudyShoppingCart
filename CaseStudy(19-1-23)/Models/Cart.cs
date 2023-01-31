using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class Cart
    {

        [Key]
        public int CId { get; set; }

        public string CUName { get; set; }

        public int PId { get; set; }


    }
}