using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageUpload.Requests
{
    public class PostRequest
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ImagePath { get; set; }
    }
}
