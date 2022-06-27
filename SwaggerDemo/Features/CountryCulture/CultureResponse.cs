using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SwaggerDocumentation.SwaggerDemo.Features.CountryCulture;

[SwaggerSchema(
    Title = "Country response.",
    Required = new[] { "TwoLetterIsoLanguageName", "Name" }
)]
public sealed class CultureResponse
{
    [Required]
    [SwaggerSchema(
        Description = "Region/Country two letter ISO language name.",
        Title = "Country Two Letter Iso Language Name"
    )]
    public string TwoLetterIsoLanguageName { get; init; } = string.Empty;

    [Required]
    [SwaggerSchema(Description = "Region/Country culture name.", Title = "Country name.")]
    public string Name { get; init; } = string.Empty;
}
