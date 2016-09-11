using AndroidShowcase.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndroidShowcase.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IAndroidShowcaseRepository showcaseRepo;

        public ProductController(IAndroidShowcaseRepository showcaseRepoParameter)
        {
            this.showcaseRepo = showcaseRepoParameter;
        }

        // GET: Products
        public ViewResult List()
        {
            var products = showcaseRepo.Products();
            return View(products);
        }
    }
}