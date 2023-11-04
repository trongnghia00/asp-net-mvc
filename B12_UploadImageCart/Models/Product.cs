using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using B12_UploadImageCart.CustomValidation;

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
        [PriceDivisibleBy1000(ErrorMessage = "Giá sản phẩm phải chia hết cho 1000.")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int Price { get; set; } = 0;
        
        public string Image {  get; set; }
    }
}