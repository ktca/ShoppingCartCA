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
        [Required]
        public int UserID { get; set; }
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }
    }
}