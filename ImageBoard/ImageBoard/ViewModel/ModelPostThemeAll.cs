using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageBoard.Models;

namespace ImageBoard.ViewModel
{
    public class ModelPostThemeAll
    {
        public User users { get; set; }
        public IEnumerable<Theme> Themes { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}