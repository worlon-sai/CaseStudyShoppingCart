using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class Products
    {

        [Key]
        public int PId { get; set; }

        public string PName { get; set; }

        public int PStocks { get; set; }

        public double PPrice { get; set; }

        public string PImage { get; set; }

        public virtual SubCategory subCategory { get; set; }

        public int SuId { get; set; }

    }
}