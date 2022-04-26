using System.Security.Claims;
using IisRest.Contracts.Dtos.BoughtAsset;
using IisRest.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IisRest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BoughtAssetController : ControllerBase
    {
        private readonly IBoughtAssetService _service;

        public BoughtAssetController(IBoughtAssetService soldAssetService)
        {
            _service = soldAssetService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BoughtAssetReadDto>> GetAll()
        {
            GetUserData(out int userId, out string userName, out string email);

            return Ok(_service.GetAll(userId));
        }

        [HttpGet("{id}", Name = "GetBoughtAssetsById")]
        public ActionResult<BoughtAssetReadDto> GetBoughtAssetsById(int id)
        {
            GetUserData(out int userId, out string userName, out string email);
            return Ok(_service.GetById(userId, id));
        }

        [HttpPost]
        public ActionResult<BoughtAssetReadDto> CreateBoughtAssetRecord([FromBody] BoughtAssetCreateDto boughtAssetDto)
        {
            GetUserData(out int userId, out string userName, out string email);

            BoughtAssetReadDto boughtAsset = _service.Create(userId, boughtAssetDto);
            return CreatedAtRoute(nameof(GetBoughtAssetsById), new { Id = boughtAsset.Id }, boughtAsset);
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
