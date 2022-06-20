namespace Domain.Common
{
    public interface IEntity
    {
        object Id { get; set; }

        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

    }

}
