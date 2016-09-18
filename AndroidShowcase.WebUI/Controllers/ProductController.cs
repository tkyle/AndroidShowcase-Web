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

        public ViewResult List()
        {
            var productsViewModel = new ProductsViewModel() { Products = showcaseRepo.Products() };
            
            return View(productsViewModel);
        }

        [HttpGet]
        public PartialViewResult GetProductDialog(string productid, string userid)
        {
            var productDialogViewModel = new ProductDialogViewModel();

            if(string.IsNullOrWhiteSpace(productid) || string.IsNullOrWhiteSpace(userid))
            {
                productDialogViewModel.IsNew = true;
            }
            else
            {
                var product = showcaseRepo.GetProduct(productid, userid);

                productDialogViewModel.ProductBO = product;
                productDialogViewModel.IsNew = false; 
            }

            return PartialView("ProductDialog", productDialogViewModel);
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

        [HttpPost]
        public ActionResult UpdateOrInsertProduct(ProductDialogViewModel productDialogViewModel)
        {
            productDialogViewModel.ProductBO.Cost = Math.Round(productDialogViewModel.ProductBO.Cost, 2);

            if (productDialogViewModel.IsNew)
                showcaseRepo.InsertProduct(productDialogViewModel.ProductBO);
            else
                showcaseRepo.UpdateProduct(productDialogViewModel.ProductBO);

            return RedirectToAction("List");

        }
    }
}