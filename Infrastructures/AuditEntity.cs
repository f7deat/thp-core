using System.ComponentModel.DataAnnotations;

namespace THPCore.Infrastructures;

public interface IAuditEntity : IBaseEntity
{
    string CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    string? ModifiedBy { get; set; }
    DateTime? ModifiedDate { get; set; }
}

public interface IAuditEntity<T> : IBaseEntity<T>
{
    string CreatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    string? ModifiedBy { get; set; }
    DateTime? ModifiedDate { get; set; }
}

public class AuditEntity : BaseEntity, IAuditEntity
{
    [StringLength(256)]
    public string CreatedBy { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    [StringLength(256)]
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

public class AuditEntity<T> : BaseEntity<T>, IAuditEntity<T>
{
    [StringLength(256)]
    public string CreatedBy { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    [StringLength(256)]
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
