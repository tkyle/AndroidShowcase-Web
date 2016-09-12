using AndroidShowcase.Business.Abstract;
using AndroidShowcase.WebUI.Models;
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
            var productsViewModel = new ProductsViewModel() { Products = showcaseRepo.Products() };
            
            return View(productsViewModel);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Delete(string productid, string userid)
        {
            showcaseRepo.DeleteProduct(productid, userid);

            return PartialView("ProductList", showcaseRepo.Products());
        }
    }
}