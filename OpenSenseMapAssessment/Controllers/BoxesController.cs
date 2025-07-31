using Microsoft.AspNetCore.Mvc;
using OpenSenseMapAssessment.Models.SenseBox;
using OpenSenseMapAssessment.Services.SenseBox;
using System.Net;

namespace OpenSenseMapAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxesController: ControllerBase
    {
        private readonly ISenseBoxService _senseBoxService;
        public BoxesController(ISenseBoxService senseBoxService)
        {
            _senseBoxService = senseBoxService;
        }

        /// <summary>
        /// Creates a new SenseBox in OpenSenseMap.
        /// </summary>
        /// <param name="request">The SenseBox details including name, model, exposure, location, and sensors.</param>
        /// <returns>Returns the created SenseBox details with a unique ID.</returns>
        /// <response code="200">SenseBox created successfully</response>
        /// <response code="403">Authentication failed or invalid JWT token</response>
        /// <response code="415">Invalid or missing content type</response>
        /// <response code="400">Bad request due to invalid data or API response</response>
        /// <response code="500">Unexpected server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateSenseBox([FromBody] SenseBoxRequest request)
        {
            try
            {
                var result = await _senseBoxService.CreateNewSenseBoxAsync(request);
                return Ok(result);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Forbidden)
            {
                return StatusCode(403, new { message = "Invalid JWT. Please sign in." });
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.UnsupportedMediaType)
            {
                return StatusCode(415, new { message = "Invalid or missing content type." });
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Unexpected error: {ex.Message}" });
            }

        }


        /// <summary>
        /// Retrieves a SenseBox by its unique ID.
        /// </summary>
        /// <param name="senseBoxId">The unique identifier of the SenseBox.</param>
        /// <returns>Returns the SenseBox details if found.</returns>
        /// <response code="200">SenseBox found and returned</response>
        /// <response code="404">SenseBox not found or invalid ID</response>
        /// <response code="500">Unexpected server error</response>
        [HttpGet("{senseBoxId}")]
        public async Task<IActionResult> GetSenseBox(string senseBoxId)
        {
            try
            {
                var senseBox = await _senseBoxService.GetSenseBoxByIdAsync(senseBoxId);
                return Ok(senseBox);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
