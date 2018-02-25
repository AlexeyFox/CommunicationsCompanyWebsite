using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web3PonApplication.Models
{
    public class Worker
    {
        [Key]
        [Required]
        [RegularExpression("^[1-9]([0-9]{8})$", ErrorMessage = "Invalid ID")]
        [Remote("IDExist", "Worker", HttpMethod = "Post", ErrorMessage = "ID already exists.")]
        public string ID { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 2,ErrorMessage = "The first name must be between 2 and 50 characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must be between 2 and 50 characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "Invalid last name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^05[0-9]([0-9]{7})$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression("^[fFmM]$", ErrorMessage = "Invalid gender")]
        public string Gender { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "The email is too long")]
        [RegularExpression("^[a-zA-Z]([a-zA-Z0-9])*@gmail.com$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^((0[1-9])|([1-2][0-9])|30|31)/(0[1-9]|10|11|12)/((1[9][3-9][0-9])|200[0-9])$", ErrorMessage = "Invalid date of birth")]
        public string DateOfBirth { get; set; }

        [Required]
        [RegularExpression("^(Manager|CEO)$", ErrorMessage = "The profession must be or Manager or CEO")]
        public string Profession { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The user name must be between 2 and 50 characters")]
        [Remote("UserNameExist", "Worker", HttpMethod = "Post", ErrorMessage = "User name already exists.")]
        [RegularExpression("^[a-zA-z][0-9a-zA-Z]*$", ErrorMessage = "Invalid user name")]
        public string UserName { get; set; }
    }
}