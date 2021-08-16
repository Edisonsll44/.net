using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class StorageEntity
    {
        [Key]
        [StringLength(50)]
        public string StorageId { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public int PartialQuantity { get; set; }

        public string ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public string WherehouseEntityId { get; set; }
        public WherehouseEntity  Wherehouse { get; set; }

    }
}
