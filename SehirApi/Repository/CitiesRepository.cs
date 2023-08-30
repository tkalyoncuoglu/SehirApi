using SehirApi.Data;
using SehirApi.Models;

namespace SehirApi.Repository
{
    public class CitiesRepository : BaseRepository<City>, ICitiesRepository
    {
        public CitiesRepository(DataContext context) : base(context) { }
    }
}
