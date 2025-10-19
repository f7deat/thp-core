namespace THPCore.Constants;

/// <summary>
/// Represents a collection of predefined role names used for user role management.
/// </summary>
/// <remarks>This class provides a set of constant string values that define various roles within an organization.
/// These roles can be used to assign permissions or categorize users based on their responsibilities.</remarks>
public class RoleName
{
    /// <summary>
    /// Represents the role name for an administrator.
    /// </summary>
    public const string Admin = nameof(Admin);
    /// <summary>
    /// Represents the role of an editor in the application.
    /// </summary>
    public const string Editor = nameof(Editor);
    /// <summary>
    /// Represents the role name for a user with student privileges.
    /// </summary>
    public const string Student = nameof(Student);
    /// <summary>
    /// Represents the name of the "Staff" role as a constant string.
    /// </summary>
    public const string Staff = nameof(Staff);
    /// <summary>
    /// Represents the name of the "Deputy" role as a constant string.
    /// </summary>
    /// <remarks>This constant can be used to reference the "Deputy" role in a consistent and type-safe manner
    /// throughout the application.</remarks>
    public const string Deputy = nameof(Deputy);
    /// <summary>
    /// The Head of Department (Trưởng đơn vị) role.
    /// </summary>
    public const string HOD = nameof(HOD);
    /// <summary>
    /// Represents the string constant for the "Nhân sự" identifier.
    /// </summary>
    public const string HR = nameof(HR);
    /// <summary>
    /// Phó hiệu trưởng
    /// </summary>
    public const string ViceRector = nameof(ViceRector);
    /// <summary>
    /// Hiệu trưởng
    /// </summary>
    public const string Rector = nameof(Rector);
    /// <summary>
    /// Represents the name of the "Instructor" role as a constant string.
    /// </summary>
    public const string Instructor = nameof(Instructor);
}
