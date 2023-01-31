using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class WishList
    {

        [Key]
        public int WId { get; set; }

        public int PId { get; set; }

        public string PUName { get; set; }

    }
}