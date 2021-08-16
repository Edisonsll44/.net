using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class B_Product : IB_Product
    {
        public  void CreateProduct(ProductEntity productEntity)
        {
            using var db = new InventoryContext();
            db.Products.Add(productEntity);
            db.SaveChanges();
        }

        public IList<ProductEntity> ListProduct()
        {
            using var db = new InventoryContext();
            return db.Products.Include("Category").ToList();
          
        }

        public void UpdateProduct(ProductEntity product)
        {
            using var db = new InventoryContext();
            db.Products.Update(product);
            db.SaveChanges();
        }

        public ProductEntity ProductById(string id)
        {
            using var db = new InventoryContext();
            return db.Products.ToList().LastOrDefault(p => p.ProductId == id);

        }
    }
}
