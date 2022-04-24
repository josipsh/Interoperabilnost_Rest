using IisRest.Contracts.Dtos;
using Microsoft.AspNetCore.Identity;

namespace IisRest.Contracts.Entities
{
    public class Profile : IdentityUser<int>, IBaseEntity
    {
        public override int Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public List<BoughtAsset> BoughtAssets { get; set; } = default!;
        public List<SoldAsset> SoldAssets { get; set; } = default!;

        public Profile()
        {
            UserName = $"{Guid.NewGuid()}";
        }

        public BasicRegisterResponse ToRegisterResponse()
        {
            return new BasicRegisterResponse()
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName,
                UserName = UserName,
            };
        }
    }
}
