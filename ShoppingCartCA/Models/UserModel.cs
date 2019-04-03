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
        public int userId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        public string password { get; set; }
    }
}