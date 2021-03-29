using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCatetgories;

        public ProductCategoryRepository()
        {
            productCatetgories = cache["productCatetgories"] as List<ProductCategory>;
            if (productCatetgories == null)
            {
                productCatetgories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productCatetgories"] = productCatetgories;
        }
        public void Insert(ProductCategory p)
        {
            productCatetgories.Add(p);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCatetgories.Find(p => p.Id == productCategory.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Catetgory not found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCatetgories.Find(p => p.Id == Id);

            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }

        }
        public IQueryable<ProductCategory> Collection()
        {
            return productCatetgories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCatetgories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                productCatetgories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}

