using SignalRExampleData.Models;
using System.Web.Mvc;

namespace SignalRExampleData.Controllers
{
    public class HomeController : Controller
    {
        private InventoryContext _inventoryContext = new InventoryContext();
        public HomeController()
        {
        }

     
        public ActionResult Index(CategoryModel category)
        {
            if (category.CategoryId != null && category.CategoryName != null)
            {
                _inventoryContext.Categories.Add(Map(category));
                _inventoryContext.SaveChanges();
                return View();
            }
            return View();
        }
        Categories Map(CategoryModel model)
        => new Categories { CategoryId = model.CategoryId, CategoryName = model.CategoryName };
    }
}