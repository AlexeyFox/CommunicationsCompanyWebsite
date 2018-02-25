using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web3PonApplication.Models
{
    public class Activity
    {
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}