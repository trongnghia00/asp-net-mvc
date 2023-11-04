using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace B12_UploadImageCart.CustomValidation
{
    public class PriceDivisibleBy1000 : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int price)
            {
                return price % 1000 == 0;
            }
            return false;
        }
    }
}