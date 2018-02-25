using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web3PonApplication.Models;

namespace Web3PonApplication.ModelView
{
    public class WorkerViewModel
    {
        public Worker worker { get; set; }
        public List<Worker> workers { get; set; }
        public User user { get; set; }
    }
}