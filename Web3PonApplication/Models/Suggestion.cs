using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web3PonApplication.Models
{
    public class Suggestion
    {
        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The first name must be between 2 and 50 characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The last lastname must be between 2 and 50 characters")]
        [RegularExpression("^[a-zA-z]*$", ErrorMessage = "Invalid last name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "The description must be between 10 and 200 characters")]
        [RegularExpression("^[a-zA-z0-9.,' ]*$", ErrorMessage = "Invalid description")]
        public string Description { get; set; }
        [Required]
        [RegularExpression("^(Jerusalem|Tev-Aviv|Beer Sheva|Haifa|Ashdod)$", ErrorMessage = "The location must be: Jerusalem or Tev-Aviv or Beer Sheva or Haifa or Ashdod")]
        public string Location { get; set; }
        [Required]
        [RegularExpression("^([0-9])+$", ErrorMessage = "Wrong size")]
        public string Area { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        [RegularExpression("^05[0-9]([0-9]{7})$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The project name must be between 2 and 50 characters")]
        [RegularExpression("^([a-zA-Z])+$", ErrorMessage = "Wrong project name")]
        public string ProjectName { get; set; }
    }
}