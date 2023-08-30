using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SehirApi.Dtos.Response
{
    public class CityDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PhotoDto> Photos { get; set; }
    }
}
