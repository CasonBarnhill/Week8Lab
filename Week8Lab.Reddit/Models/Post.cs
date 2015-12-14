using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Week8Lab.Reddit.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        [NotMapped]
        public int Popularity { get { return Up - Down; } }
        public DateTime PostDate { get; set; }
        public virtual User User { get; set; }
       

    }
}