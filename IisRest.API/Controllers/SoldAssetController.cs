using AutoMapper;
using IisRest.Contracts.Dtos;
using IisRest.Contracts.Entities;
using IisRest.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace IisRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldAssetController : ControllerBase
    {
        private readonly ISoldAssetService _service;
        private readonly IMapper _mapper;

        public SoldAssetController(ISoldAssetService soldAssetService, IMapper mapper)
        {
            _service = soldAssetService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SoldAssetReadDto>> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<SoldAssetReadDto>>(_service.GetAll()));
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<SoldAssetReadDto> GetById(int id)
        {
            return Ok(_mapper.Map<SoldAssetReadDto>(_service.GetById(id)));
        }

        [HttpPost]
        public ActionResult<SoldAsset> CreateSoldAssetRecord([FromBody] SoldAssetCreateDto soldAssetDto)
        {
            SoldAsset soldAsset = _mapper.Map<SoldAsset>(soldAssetDto);
            soldAsset.ProfileId = 6;
            _service.Create(soldAsset);
            return CreatedAtRoute(nameof(GetById), new { Id = soldAsset.Id }, _mapper.Map<SoldAssetReadDto>(soldAsset));
        }
    }
}
