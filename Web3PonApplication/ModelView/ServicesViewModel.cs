using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web3PonApplication.Models;

namespace Web3PonApplication.ModelView
{
    public class ServicesViewModel
    {
        public Service service { get; set; }
        public List<Service> services { get; set; }
    }
}