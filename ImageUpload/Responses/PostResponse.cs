using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ImageUpload.Responses.Models;

namespace ImageUpload.Responses
{
    public class PostResponse
    {
        public PostModel Post { get; set; }
    }
}
