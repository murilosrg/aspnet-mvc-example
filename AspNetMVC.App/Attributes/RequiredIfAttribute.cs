using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC.App.Attributes
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (bool)value;
        }
    }
}
