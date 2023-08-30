using SehirApi.Models;

namespace SehirApi.Dtos.Response
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
