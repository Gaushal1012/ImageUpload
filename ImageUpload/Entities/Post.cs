using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUpload.Entities
{
    public partial class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Imagepath { get; set; }
        public DateTime Ts { get; set; }
        public bool Published { get; set; }
    }
}
