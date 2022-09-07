using IWantApp.ViewModels;

namespace IWantApp.Endpoints;

public class ApiBase
{
    #region [IResult]

    protected static IResult CreatedOk<TData>(string uri, TData data) where TData : class
    {
        return Results.Created(uri, new ResultViewModel<TData>(data));
    }

    protected static IResult ResultOk<TData>(TData data) where TData : class
    {
        return Results.Ok(new ResultViewModel<TData>(data));
    }

    protected static IResult ResultOk(string data)
    {
        return Results.Ok(new ResultViewModel<string>(data, null!));
    }

    protected static IResult ResultError(IList<string> errors)
    {
        return Results.BadRequest(new ResultViewModel<string>(errors));
    }

    protected static IResult ResultError(string error)
    {
        return Results.BadRequest(new ResultViewModel<string>(error));
    }

    protected static IResult ResultNotFound(string message)
    {
        return Results.NotFound(new ResultViewModel<string>(message));
    }

    #endregion
}