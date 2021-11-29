using Application.Interface.Review.Model;
using Application.Interface.Review.Service;
using Burger_Backend.Infrastrukture;
using CrossTools.ResultHandling.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Burger_Backend.Review
{
    //[Authorize]
    [Route("api/review-management")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewApplication _reviewApplication;
        private readonly IActionResultService _actionResultService;

        public ReviewController(IReviewApplication reviewApplication, IActionResultService actionResultService)
        {
            _reviewApplication = reviewApplication ?? throw new ArgumentNullException(nameof(reviewApplication));
            _actionResultService = actionResultService ?? throw new ArgumentNullException(nameof(actionResultService));
        }

        [HttpGet]
        [VersionRoute("reviews/{id}", RouteVersion = RouteVersion.V1)]
        public async Task<ActionResult<IErrorResult<ReviewReadDto, ISimpleError>>> GetReviewAsync([FromRoute(Name = "id")] int id)
        {
            var result = await _reviewApplication.GetAsync(id);
            return _actionResultService.OkOrError(result);
        }

        [HttpGet]
        [VersionRoute("reviews/{rating}", RouteVersion = RouteVersion.V1)]
        public async Task<ActionResult<IErrorResult<ReviewReadDto, ISimpleError>>> GetReviewAsync(
           [FromRoute(Name = "rating")] int rating, [FromQuery(Name = "zip-code")] string zipCode)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [VersionRoute("reviews")]
        public async Task<ActionResult<IErrorResult<int?, IExtendedError<ReviewWriteDto>>>> CreateReviewAsync([FromBody] ReviewWriteDto reviewWriteDto)
        {
            var result = await _reviewApplication.CreateAsync(reviewWriteDto);
            return _actionResultService.OkOrError(result);
        }

        [HttpDelete]
        [VersionRoute("reviews/{id}")]
        public async Task<ActionResult<IErrorResult<IExtendedError<ReviewWriteDto>>>> DeleteReviewAsync([FromRoute(Name = "id")] int id)
        {
            var result = await _reviewApplication.DeleteAsync(id);
            return _actionResultService.NoContentOrError(result);
        }
    }
}