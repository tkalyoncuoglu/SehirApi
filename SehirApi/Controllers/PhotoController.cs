using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SehirApi.Models;
using SehirApi.Dtos.Response;
using SehirApi.Repository;

namespace SehirApi.Controllers
{
    [Route("api/cities/{cityId}/photos")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotosRepository _photosRepository;
        private readonly ICitiesRepository _citiesRepository;
        private readonly IMapper _mapper;

        public PhotoController(IPhotosRepository photosRepository, ICitiesRepository citiesRepository, IMapper mapper)
        {
            _photosRepository = photosRepository;
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddPhotoForCity(int cityId, [FromForm] Dtos.Request.PhotoDto photoForCreationDto)
        {
            var city=_citiesRepository.GetById(cityId);
            if(city == null)
            {
                return BadRequest("Could not find the city");
            }
            
            var file=photoForCreationDto.File;
            MemoryStream stream = new MemoryStream();
            if(file.Length > 0)
            {
                file.CopyTo(stream);
            }
            
            var photo = _mapper.Map<Photo>(photoForCreationDto);
            photo.File = stream.ToArray();

            city.Photos.Add(photo);
            if (_photosRepository.SaveAll())
            {
                return Ok();
            }
            return BadRequest("Could Not Add Photo");
        }
        [HttpGet("{id}",Name ="GetPhoto")]
        public IActionResult GetPhoto(int id)
        {
            var photofromDb=_photosRepository.GetById(id);
            var photo= _mapper.Map<Dtos.Response.PhotoDto>(photofromDb);
            return Ok(photo);
        }
    }
}
