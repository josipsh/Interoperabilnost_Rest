namespace IisRest.Contracts.Entities
{
    public interface IBaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
