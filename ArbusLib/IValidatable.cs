using System.ComponentModel.DataAnnotations;

namespace ArbusTest;

public interface IValidatable
{
    /// <summary>Determines whether the specified object is valid.</summary>
    /// <param name="validationContext">The validation context.
    /// <returns>A collection that holds failed-validation information.</returns>
    void Validate (ValidationContext validationContext);
}