namespace IisRest.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        public IBoughtAssetRepository BoughtAssetRepository { get; }
        public ISoldAssetRepository SoldAssetRepository { get; }

        void SaveChanges();
    }
}
