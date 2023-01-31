using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class Category
    {
        [Key]
        public  int CAId { get; set; }


        public string CAName { get; set; }

        public virtual ICollection<SubCategory> subCategories { get; set; }
    }
}