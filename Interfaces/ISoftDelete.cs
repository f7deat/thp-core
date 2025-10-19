namespace THPCore.Interfaces;

/// <summary>
/// Represents an entity that supports soft deletion functionality.
/// </summary>
/// <remarks>Soft deletion allows an entity to be marked as deleted without being permanently removed from the
/// data store. This is typically used to preserve historical data or to enable recovery of deleted entities.</remarks>
public interface ISoftDelete
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    bool IsDeleted { get; set; }
}
