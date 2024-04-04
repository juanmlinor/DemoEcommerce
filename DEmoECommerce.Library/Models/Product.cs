using System.ComponentModel.DataAnnotations;

namespace DEmoECommerce.Library.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        //[DisplayName("Is Active")]
        //public bool IsActive { get; set; }

        //[DisplayName("Is Starred")]
        //public bool IsStarred { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        //public ICollection<ProductImage> ProductImages { get; set; }

        //[DisplayName("Product Images Number")]
        //public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        ////TODO: Pending to put the correct paths
        //[Display(Name = "Image")]
        //public string ImageFullPath => ProductImages == null || ProductImages.Count == 0
        //    ? $"https://localhost:27899/images/noimage.png"
        //    : ProductImages.FirstOrDefault().ImageFullPath;
    }
}
