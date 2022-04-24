namespace IisRest.Contracts.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
