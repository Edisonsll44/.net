using System.ComponentModel.DataAnnotations;

namespace SignalRExampleData.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Ingrese un código de categoría")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre de categoría")]
        public string CategoryName { get; set; }
    }
}