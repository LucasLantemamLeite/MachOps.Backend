namespace MachOps.Application.Shared.ResultCases;

public sealed class Result<T>
{
    public string? Message { get; }
    public bool Success { get; }
    public T? Data { get; } = default!;

    public Result(bool success, string? message = null, T? data = default)
    {
        Message = message;
        Success = success;
        Data = data;
    }

    public static Result<T> Ok(string? message, T? data) => new Result<T>(true, message, data);

    public static Result<T> Fail(string? message) => new Result<T>(false, message);
}