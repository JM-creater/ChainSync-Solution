using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChainSyncSolution.Domain.BaseDomain;

public abstract class BaseEntity
{
    public BaseEntity(Guid id,
        DateTimeOffset dateCreated,
        DateTimeOffset dateUpdated,
        DateTimeOffset? dateDeleted)
    {
        Id = id;
        DateCreated = dateCreated;
        DateUpdated = dateUpdated;
        DateDeleted = dateDeleted;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTimeOffset DateCreated { get; private set; }
    public DateTimeOffset DateUpdated { get; private set; }
    public DateTimeOffset? DateDeleted { get; private set; }

    // Methods to set fields
    public void SetGuidId(Guid id)
    {
        Id = id; 
    }
    public void SetDateCreated(DateTimeOffset dateCreated)
    {
        DateCreated = dateCreated;
    }
    public void SetDateUpdated(DateTimeOffset dateUpdated)
    {
        DateUpdated = dateUpdated;
    }

    public void SetDateDeleted(DateTimeOffset? dateDeleted)
    {
        DateDeleted = dateDeleted;
    }
}
