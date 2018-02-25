using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web3PonApplication.Models
{
    public class Project
    {
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
    }
}