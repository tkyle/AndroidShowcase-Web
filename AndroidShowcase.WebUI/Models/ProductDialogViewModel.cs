using AndroidShowcase.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndroidShowcase.WebUI.Models
{
    public class ProductDialogViewModel
    {
        public bool IsNew  { get; set; }
        public Product ProductBO { get; set; }
    }
}