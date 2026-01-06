namespace ForgeFolio.Core.Entities;

/// <summary>
/// Base entity class providing common properties for all entities
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Unique identifier for the entity
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Date and time when the entity was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Date and time when the entity was last updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Indicates whether the entity is soft deleted
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// Date and time when the entity was soft deleted
    /// </summary>
    public DateTime? DeletedAt { get; set; }
}
