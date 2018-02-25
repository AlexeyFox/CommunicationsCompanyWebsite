using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web3PonApplication.Models;

namespace Web3PonApplication.ModelView
{
    public class SuggestionViewModel
    {
        public Suggestion suggestion { get; set; }
        public List<Suggestion> suggestions { get; set; }
    }
}