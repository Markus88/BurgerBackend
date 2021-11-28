using Application.Interface.User.Model;
using Application.Interface.User.Service;
using Burger_Backend.Infrastrukture;
using CrossTools.ResultHandling.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Burger_Backend.User
{
    //[Authorize]
    [Route("api/user-management")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        private readonly IActionResultService _actionResultService;

        public UserController(IUserApplication userApplication, IActionResultService actionResultService)
        {
            _userApplication = userApplication ?? throw new ArgumentNullException(nameof(userApplication));
            _actionResultService = actionResultService ?? throw new ArgumentNullException(nameof(actionResultService));
        }

        [HttpGet]
        [VersionRoute("users/{id}", RouteVersion = RouteVersion.V1)]
        public async Task<ActionResult<IErrorResult<UserReadDto, ISimpleError>>> GetUserAsync([FromRoute(Name = "id")] int id)
        {
            var result = await _userApplication.GetAsync(id);
            return _actionResultService.OkOrError(result);
        }

        [HttpPut]
        [VersionRoute("users")]
        public async Task<ActionResult<IErrorResult<IExtendedError<UserWriteDto>>>> UpdateUserAsync([FromBody] UserWriteDto userWriteDto)
        {
            var result = await _userApplication.UpdateAsync(userWriteDto);
            return _actionResultService.NoContentOrError(result);
        }

        [HttpPost]
        [VersionRoute("users")]
        public async Task<ActionResult<IErrorResult<int?, IExtendedError<UserWriteDto>>>> CreateUserAsync([FromBody] UserWriteDto userWriteDto)
        {
            var result = await _userApplication.CreateAsync(userWriteDto);
            return _actionResultService.OkOrError(result);
        }

        [HttpDelete]
        [VersionRoute("users/{id}")]
        public async Task<ActionResult<IErrorResult<IExtendedError<UserWriteDto>>>> DeleteUserAsync([FromRoute(Name = "id")] int id)
        {
            var result = await _userApplication.DeleteAsync(id);
            return _actionResultService.NoContentOrError(result);
        }
    }
}