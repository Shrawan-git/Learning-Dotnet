using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProrductCategory
        ProductCategoryRepository context;

        public ProductCategoryManagerController()
        {
            context = new ProductCategoryRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCatetgories = context.Collection().ToList();
            return View(productCatetgories);
        }

        public ActionResult Create()
        {
            ProductCategory productCatetgory = new ProductCategory();
            return View(productCatetgory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCatetgory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCatetgory);
            }
            else
            {
                context.Insert(productCatetgory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCatetgory = context.Find(Id);
            if (productCatetgory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCatetgory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory product, string Id)
        {
            ProductCategory productCatetgoryToEdit = context.Find(Id);
            if (productCatetgoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                productCatetgoryToEdit.Category = product.Category;


                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCatetgoryToDelete = context.Find(Id);
            if (productCatetgoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCatetgoryToDelete);
            }
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCatetgoryToDelete = context.Find(Id);

            if (productCatetgoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
    }