using IisRest.Contracts.Entities;

namespace IisRest.Contracts.Extensions
{
    public static class EnumExtensions
    {
        public static AssetType GetAssetTypeFromInt(this int val)
        {
            if (Enum.IsDefined(typeof(AssetType), val))
            {
                return (AssetType)val;
            }

            return AssetType.Crypto;
        }
    }
}
