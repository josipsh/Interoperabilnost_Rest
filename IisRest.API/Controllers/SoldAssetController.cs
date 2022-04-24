using IisRest.Contracts.Dtos.SoldAsset;
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

        public SoldAssetController(ISoldAssetService soldAssetService)
        {
            _service = soldAssetService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SoldAssetReadDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<SoldAssetReadDto> GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult<SoldAsset> CreateSoldAssetRecord([FromBody] SoldAssetCreateDto soldAssetDto)
        {
            SoldAssetReadDto soldAsset = _service.Create(soldAssetDto);
            return CreatedAtRoute(nameof(GetById), new { Id = soldAsset.Id }, soldAsset);
        }
    }
}
