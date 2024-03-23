using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rainfall.API.Common.CustomExceptions;
using Rainfall.API.Common.Models;
using Rainfall.API.Common.Services.Abstracts;
using System.Net;

namespace Rainfall.API.Controllers
{
    /// <summary>
    /// </summary>
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        /// <summary>
        /// </summary>
        public IRainfallService _rainfallService;
        /// <summary>
        /// </summary>
        public RainfallController(
             IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }
        /// <summary>
        /// Operations relating to rainfall
        /// </summary>
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified stationId</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult<RainfallReadingResponse>> GetRainfall([FromRoute] string stationId, [FromQuery] int? count = 10)
        {
            try
            {
                var item = await _rainfallService.GetRainfall(stationId, count);
                return Ok(item);
            }
            catch (NullValueException ex)
            {
                ErrorResponse errors = new ErrorResponse();
                errors.Message = ex.Message;

                errors.Detail.Add(new ErrorDetail()
                {
                    Message = "stationId not found",
                    PropertyName = "stationId",
                });

                return NotFound(errors);
            }
            catch (ArgumentException ex)
            {
                ErrorResponse errors = new ErrorResponse();
                errors.Message = ex.Message;

                errors.Detail.Add(new ErrorDetail()
                {
                    Message = "invalid count parameter passed",
                    PropertyName = "count",
                });

                return BadRequest(errors);
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

    }
}
