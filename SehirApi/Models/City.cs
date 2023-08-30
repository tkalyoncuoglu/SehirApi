using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirApi.Models
{
    public class City : IEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    }
}
