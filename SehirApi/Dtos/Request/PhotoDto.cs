using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SehirApi.Dtos.Request
{
    public class PhotoDto
    {
        public PhotoDto()
        {
            DateAdded = DateTime.Now;
        }
        public IFormFile File { get; set; }
        public DateTime? DateAdded { get; set; }

    }
}
