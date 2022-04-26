using System.Security.Claims;
using IisRest.Contracts.Dtos.SoldAsset;
using IisRest.Contracts.Entities;
using IisRest.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IisRest.API.Controllers
{
    [Authorize]
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
            GetUserData(out int userId, out string userName, out string email);

            return Ok(_service.GetAll(userId));
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<SoldAssetReadDto> GetById(int id)
        {
            GetUserData(out int userId, out string userName, out string email);
            return Ok(_service.GetById(userId, id));
        }

        [HttpPost]
        public ActionResult<SoldAsset> CreateSoldAssetRecord([FromBody] SoldAssetCreateDto soldAssetDto)
        {
            GetUserData(out int userId, out string userName, out string email);

            SoldAssetReadDto soldAsset = _service.Create(userId, soldAssetDto);
            return CreatedAtRoute(nameof(GetById), new { Id = soldAsset.Id }, soldAsset);
        }

        private void GetUserData(out int userId, out string userName, out string email)
        {
            Claim? idClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");

            if (idClaim == null)
            {
                throw new Exception();
            }

            if (!int.TryParse(idClaim.Value, out userId))
            {
                throw new Exception();
            }

            Claim? userNameClaim = User.Claims.FirstOrDefault(c => c.Type == "UserName");

            if (userNameClaim == null || userNameClaim.Value.Length == 0)
            {
                throw new Exception();
            }

            userName = userNameClaim.Value;

            Claim? emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            if (emailClaim == null || emailClaim.Value.Length == 0)
            {
                throw new Exception();
            }

            email = emailClaim.Value;
        }
    }
}
