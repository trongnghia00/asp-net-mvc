using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace B12_UploadImageCart.Models
{
    public class Product
    {
        [Key]
        public int ProId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; } = decimal.Zero;
        
        public string Image {  get; set; }
    }
}