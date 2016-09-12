using AndroidShowcase.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndroidShowcase.WebUI.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}