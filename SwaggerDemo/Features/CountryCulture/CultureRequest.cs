using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SwaggerDocumentation.SwaggerDemo.Features.CountryCulture;

[SwaggerSchema(Title = "Country response.", Required = new[] { "CultureName" })]
public sealed class CultureRequest
{
    [Required]
    [SwaggerSchema(Description = "Region/Country culture name.", Title = "Country name.")]
    public string CultureName { get; init; } = string.Empty;
}
