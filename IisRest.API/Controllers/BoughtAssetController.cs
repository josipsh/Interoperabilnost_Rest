using System.Runtime.Serialization;
using System.Security.Claims;
using System.Xml;
using System.Xml.Schema;
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

        private bool isXmlElemetValid = true;

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
        public ActionResult<BoughtAssetReadDto> CreateBoughtAssetRecord([FromBody] XmlElement boughtAssetXml)
        {
            XmlDocument xmlDocument = boughtAssetXml.OwnerDocument;
            xmlDocument.AppendChild(boughtAssetXml);
            xmlDocument.Schemas.Add("http://schemas.datacontract.org/2004/07/IisRest.Contracts.Dtos.BoughtAsset", "validations/BoughtAssetValidator.xsd");

            ValidationEventHandler validationEventHandler = new ValidationEventHandler(XmlValidationEventHandler);
            xmlDocument.Validate(validationEventHandler);

            if (!isXmlElemetValid)
            {
                throw new Exception("Xml is invalid");
            }

            GetUserData(out int userId, out string userName, out string email);

            DataContractSerializer deserializer = new DataContractSerializer(typeof(BoughtAssetCreateDto));
            MemoryStream memoeryStream = new MemoryStream();
            xmlDocument.Save(memoeryStream);
            memoeryStream.Position = 0;
            BoughtAssetCreateDto? boughtAssetDto = (BoughtAssetCreateDto?)deserializer.ReadObject(memoeryStream);

            if (boughtAssetDto is null)
            {
                throw new Exception("Unable to deserialize xml");
            }

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

        private void XmlValidationEventHandler(object? sender, ValidationEventArgs e)
        {
            isXmlElemetValid = false;
        }
    }
}
