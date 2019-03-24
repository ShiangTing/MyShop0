using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Myshop.Core.Models;


namespace Myshop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;
        
        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }

        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;

        }
        //Insert update delete find function
        public void Insert(ProductCategory c)
        {
            productCategories.Add(c);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product no Found!");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategories.Find(p => p.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product no Found!");
            }
        }
        //列出商品
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();

        }
        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove (productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product no Found!");
            }

        }
    }
}
