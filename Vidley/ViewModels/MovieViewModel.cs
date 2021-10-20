using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}