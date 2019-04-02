using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ShoppingCartCA.Models
{
    public class UserModel
    {
        [DisplayName("User ID")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}