using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    // Using non-generic integer types for simplicity and to ease caching logic
    public abstract class BaseEntity<T> : AuditableEntity, IEntity
    {

        [Key]
        [Required]
        public T Id { get; set; }

        object IEntity.Id
        {
            get { return Id; }
            set { }
        }



        public byte IsDeleted { get; set; } = 0;

        //public DateTime Created { get; set; }

        //public string? CreatedBy { get; set; }

        //public DateTime? LastModified { get; set; }

        //public string? LastModifiedBy { get; set; }

    }
}
