using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web3PonApplication.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        public string ID { get; set; }
        [Key]
        [Required]
        public string Date { get; set; }
        [Key]
        [Required]
        public string Month { get; set; }
        [Key]
        [Required]
        public string Year { get; set; }
        [Required]
        public string Start { get; set; }
        [Required]
        public string End { get; set; }
    }
}