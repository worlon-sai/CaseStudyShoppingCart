using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Models
{
    public class ViewModel
    {
        public Products products { get; set; }

        public List<Products> Lproducts { get; set; }

        public Category category { get; set; }

        public List<Category> Lcategory { get; set; }

        public SubCategory subCategory { get; set; }

        public List<SubCategory> LsubCategory { get; set; }

        public WishList wishList { get; set; }

        public List<WishList> LwishList { get; set; }

        public Order order { get; set; }

        public List<Order> Lorder { get; }

        public Cart cart { get; set; }

        public List<Cart> Lcart { get; set; }

        public Ordered ordered { get; set; }

        public List<Ordered> Lordered { get; set; }

        public string search { get; set; }
    }
}