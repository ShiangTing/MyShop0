using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Myshop.Core.Contracts;
using Myshop.Core.Models;

namespace Myshop.DataAccess.InMemory
{   // <> is a place holder, it can be placed in anything.
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        // Internal list of product/product catagory
        List<T> items;
        string className;
        // Initialize
        public InMemoryRepository()
        { // Get real name
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }

        }

        public void Commit()
        { // store items in Memory
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }
        // 因為(T t)可以是任何東西 所以不能確定是class 所以不會有Id出現
        // 需要創造一個BaseEntity
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception("Product no Found!");
            }
        }
        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception("Product no Found!");
}
        }
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();

        }
        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);
            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception("Product no Found!");
            }
        }




    }
}
