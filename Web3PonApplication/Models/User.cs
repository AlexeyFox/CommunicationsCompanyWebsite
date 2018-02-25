using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Globalization;
using TugberkUg.MVC;
using TugberkUg.MVC.Validation;

namespace Web3PonApplication.Models
{
    public class User
    {


        [Key]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The first user name must be between 2 and 50 characters")]
        /*[ServerSideRemote("Worker", "UserNameExist")]*/
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^[a-z0-9A-z]*$", ErrorMessage = "Invalid password")]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^[12]*$", ErrorMessage = "Invalid permission")]
        public int Permission { get; set; }

    }
}