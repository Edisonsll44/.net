using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class B_Category :IB_Category
    {
        public IList<CategoryEntity> CategoryList()
        {
            using var db = new InventoryContext();
            return db.Categories.ToList().OrderBy(d=> d.CategoryId).ToList();
        }

        public void CreateCategory(CategoryEntity oCategory)
        {
            using var db = new InventoryContext();
            db.Categories.Add(oCategory);
            db.SaveChanges();
        }

        public void UpdateCategory(CategoryEntity oCategory)
        {
            using var db = new InventoryContext();
            db.Categories.Update(oCategory);
            db.SaveChanges();
        }
    }
}
