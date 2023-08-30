using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirApi.Dtos.Request;
using SehirApi.Dtos;
using SehirApi.Models;
using SehirApi.Dtos.Response;
using SehirApi.Repository;

namespace SehirApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IPhotosRepository _photosRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICitiesRepository citiesRepository, IPhotosRepository photosRepository, IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _photosRepository = photosRepository;
            _mapper = mapper;
        }
        [HttpGet]

        public IActionResult GetCities()
        {
            //her seferinde böyle yapmak yerine mapping geliştirmişler
            //var cities = _appRepository.GetCities().Select(x=> new CityForListDto { Description=x.Description}).ToList();
            var cities = _citiesRepository.GetAll();
            var citiesToReturn = _mapper.Map<List<CityDto>>(cities);
            return Ok(citiesToReturn);
        }
        
        [HttpPost]
        [Route("add")]
        //[Authorize]
        public IActionResult Add(CityDto city)
        {
            var mapped = _mapper.Map<City>(city);
            _citiesRepository.Add(mapped);
            _citiesRepository.SaveAll();
            return Ok();
        }
        [HttpGet]
        [Route("detail")]
        public IActionResult GetCityById(int id)
        {
            var city = _citiesRepository.GetById(id, new string[] {"Photos"});
            var cityToReturn = _mapper.Map<CityDetailDto>(city);
            return Ok(cityToReturn);
        }
        [HttpGet]
        [Route("Photos")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _photosRepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }
    }
}
