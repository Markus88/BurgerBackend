using CrossTools.ResultHandling.Interface;
using CrossTools.ResultHandling.Interface.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Burger_Backend.Infrastrukture
{
    public class ActionResultService : IActionResultService
    {
        public ActionResult<IErrorResult<TResultValue, TError>> OkOrError<TResultValue, TError>(IErrorResult<TResultValue, TError> result) where TError : IError
        {
            if (result.Success)
            {
                return CustomOkResult(result);
            }
            else
            {
                return CreateErrorHttpResult(result);
            }
        }

        public ActionResult<IErrorResult<TError>> CreatedOrError<TError>(IErrorResult<TError> result) where TError : IError
        {
            if (result.Success)
            {
                return CustomCreatedResult(result);
            }
            else
            {
                return CreateErrorHttpResult(result);
            }
        }

        public ActionResult<IErrorResult<TResultValue, TError>> CreatedOrError<TResultValue, TError>(IErrorResult<TResultValue, TError> result) where TError : IError
        {
            if (result.Success)
            {
                return CustomCreatedResult(result);
            }
            else
            {
                return CreateErrorHttpResult(result);
            }
        }

        public ActionResult<IErrorResult<TResultValue, TError>> CreatedAtActionOrError<TResultValue, TError>(string actionName, IErrorResult<TResultValue, TError> result) where TError : IError
        {
            return CreatedAtActionOrError(actionName, null, result);
        }

        public ActionResult<IErrorResult<TResultValue, TError>> CreatedAtActionOrError<TResultValue, TError>(string actionName, object routeValues, IErrorResult<TResultValue, TError> result) where TError : IError
        {
            return CreatedAtActionOrError(actionName, null, routeValues, result);
        }

        public ActionResult<IErrorResult<TResultValue, TError>> CreatedAtActionOrError<TResultValue, TError>(string actionName, string controllerName, object routeValues, IErrorResult<TResultValue, TError> result) where TError : IError
        {
            if (result.Success)
            {
                return new CreatedAtActionResult(actionName, controllerName, routeValues, result);
            }
            else
            {
                return CreateErrorHttpResult(result);
            }
        }

        public ActionResult<TResultValue> Accepted<TResultValue>(TResultValue result)
        {
            return CustomAcceptedResult(result);
        }

        public ActionResult<IErrorResult<TError>> AcceptedOrError<TError>(IErrorResult<TError> result) where TError : IError
        {
            if (result.Success)
            {
                return CustomAcceptedResult(result);
            }
            else
            {
                return CreateErrorHttpResult(result);
            }
        }

        public ActionResult<IErrorResult<TResultValue, TError>> AcceptedOrError<TResultValue, TError>(IErrorResult<TResultValue, TError> result) where TError : IError
        {
            if (result.Success)
            {
                return CustomAcceptedResult(result);
            }
            else
            {
                return CreateErrorHttpResult(result);
            }
        }

        public ActionResult<IErrorResult<TError>> NoContentOrError<TError>(IErrorResult<TError> result) where TError : IError
        {
            if (result.Success)
            {
                return CustomNoContentResult();
            }
            else
            {
                return CreateErrorHttpResult(result);
            }
        }

        private ActionResult<IErrorResult<TError>> CreateErrorHttpResult<TError>(IErrorResult<TError> result) where TError : IError
        {
            var validationError = result?.Notification?.GetErrors().OrderBy(e => e.ValidationError.Priority).FirstOrDefault()?.ValidationError;
            return MapResult(validationError, result);
        }

        private ActionResult<IErrorResult<TResult, TError>> CreateErrorHttpResult<TResult, TError>(IErrorResult<TResult, TError> result) where TError : IError
        {
            var validationError = result?.Notification?.GetErrors().OrderBy(e => e.ValidationError.Priority).FirstOrDefault()?.ValidationError;
            return MapResult(validationError, result);
        }

        private ActionResult<TResult> MapResult<TResult>(ValidationError validationError, TResult result)
        {
            if (validationError == null) return CustomBadRequestResult(result);
            return CustomForbiddenResult(result);
        }

        private ActionResult<TResult> CustomOkResult<TResult>(TResult result)
        {
            return new OkObjectResult(result);
        }

        private ActionResult<TResult> CustomCreatedResult<TResult>(TResult result)
        {
            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        private ActionResult<TResult> CustomAcceptedResult<TResult>(TResult result)
        {
            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status202Accepted
            };
        }

        private ActionResult CustomNoContentResult()
        {
            return new ObjectResult(null)
            {
                StatusCode = StatusCodes.Status204NoContent
            };
        }

        private ActionResult<TResult> CustomForbiddenResult<TResult>(TResult result)
        {
            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }

        private ActionResult<TResult> CustomBadRequestResult<TResult>(TResult result)
        {
            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
