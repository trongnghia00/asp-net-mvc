using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace B12_UploadImageCart.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int ProId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}