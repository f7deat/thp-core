using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THPCore.Infrastructures;

public interface IBaseEntity<T>
{
    T Id { get; set; }
}

public interface IBaseEntity
{
    Guid Id { get; set; }
}

public class BaseEntity<T> : IBaseEntity<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; } = default!;
}

public class BaseEntity : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = default!;
}