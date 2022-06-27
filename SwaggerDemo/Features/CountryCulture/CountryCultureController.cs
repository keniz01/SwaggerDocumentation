using System.Globalization;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SwaggerDocumentation.SwaggerDemo.Features.CountryCulture;

/// <summary>
/// Manages app-wide culture translations.
/// </summary>
// [Route("api/v1/[controller]")] // Out of box version
[Route("api/v1/country-culture")] // https://developers.google.com/search/docs/advanced/guidelines/get-started
[ApiController]
[SwaggerSchema(Title = "Culture")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class CountryCultureController : ControllerBase
{
    [HttpPost()]
    [SwaggerOperation(Summary = "Creates culture", Description = "Creates a new culture instance.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request successful")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Check the request is valid.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Bang...something happened.")]
    public IResult CreateCulture(
        [SwaggerParameter(Description = "Culture request", Required = true)] CultureRequest request
    )
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));
        CultureInfo.CreateSpecificCulture(request.CultureName);
        return Results.Ok();
    }

    [HttpGet("{cultureName}")]
    [SwaggerOperation(Summary = "Gets culture", Description = "Gets culture by name.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Request successful", typeof(CultureResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "Check the request is valid.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Bang...something happened.")]
    public IResult GetCultureByName(
        [SwaggerParameter(Description = "Culture name", Required = true)] string cultureName
    )
    {
        cultureName ??= "en-GB";

        var cultureInfo = CultureInfo.CreateSpecificCulture(cultureName);
        var response = new CultureResponse
        {
            TwoLetterIsoLanguageName = cultureInfo.TwoLetterISOLanguageName,
            Name = cultureInfo.Name
        };

        return Results.Ok(response);
    }
}
