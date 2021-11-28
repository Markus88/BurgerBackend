using CrossTools.ResultHandling.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Burger_Backend.Infrastrukture
{
    public interface IActionResultService
    {
        ActionResult<IErrorResult<TResult, TError>> OkOrError<TResult, TError>(IErrorResult<TResult, TError> result) where TError : IError;
        ActionResult<IErrorResult<TError>> CreatedOrError<TError>(IErrorResult<TError> result) where TError : IError;
        ActionResult<IErrorResult<TResultValue, TError>> CreatedOrError<TResultValue, TError>(IErrorResult<TResultValue, TError> result) where TError : IError;
        ActionResult<IErrorResult<TResultValue, TError>> CreatedAtActionOrError<TResultValue, TError>(string actionName, IErrorResult<TResultValue, TError> result) where TError : IError;
        ActionResult<IErrorResult<TResultValue, TError>> CreatedAtActionOrError<TResultValue, TError>(string actionName, object routeValues, IErrorResult<TResultValue, TError> result) where TError : IError;
        ActionResult<IErrorResult<TResultValue, TError>> CreatedAtActionOrError<TResultValue, TError>(string actionName, string controllerName, object routeValues, IErrorResult<TResultValue, TError> result) where TError : IError;
        ActionResult<TResultValue> Accepted<TResultValue>(TResultValue result);
        ActionResult<IErrorResult<TError>> AcceptedOrError<TError>(IErrorResult<TError> result) where TError : IError;
        ActionResult<IErrorResult<TResultValue, TError>> AcceptedOrError<TResultValue, TError>(IErrorResult<TResultValue, TError> result) where TError : IError;
        ActionResult<IErrorResult<TError>> NoContentOrError<TError>(IErrorResult<TError> result) where TError : IError;
    }
}
