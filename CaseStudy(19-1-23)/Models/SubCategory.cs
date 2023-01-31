using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class SubCategory
    {
        [Key]

        public int SuId { get; set; }

        public string SuName { get; set; }

        public virtual Category category { get; set; }

        public int CAId { get; set; }

        public ICollection<Products> products { get; set; }
    }
}