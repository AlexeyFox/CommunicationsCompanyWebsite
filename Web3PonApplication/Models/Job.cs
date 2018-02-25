using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web3PonApplication.Models
{
    public class Job
    {
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The first name must be between 2 and 50 characters")]
        public string JobName { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "The first name must be between 2 and 50 characters")]
        public string JobDescription { get; set; }
    }
}