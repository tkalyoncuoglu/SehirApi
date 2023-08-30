using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirApi.Models
{
    public class Photo : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public byte[] File { get; set; }
        public DateTime DateAdded { get; set; }   
        public virtual City City { get; set; }

    }
}
