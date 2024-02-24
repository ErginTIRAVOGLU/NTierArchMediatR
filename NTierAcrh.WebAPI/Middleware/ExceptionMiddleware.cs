namespace NTierAcrh.WebAPI.Middleware;

public sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{

			await HandleExceiptionAsync(context, ex);
		}
    }

	private Task HandleExceiptionAsync(HttpContext context, Exception ex)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = 500;

		return context.Response.WriteAsync(new ErrorResult()
		{
            Message = ex.Message
        }.ToString());
	}
}
