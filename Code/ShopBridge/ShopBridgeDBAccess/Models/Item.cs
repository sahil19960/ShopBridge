using System.ComponentModel.DataAnnotations;

namespace ShopBridgeDBAccess.Models
{
    /// <summary>
    /// Item is an entity that represents an item of the inventory.
    /// </summary>
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }
    }
}
