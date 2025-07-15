using Apllication.Validations;
namespace WepApi.Middlewares
{
    public class CustomMiddlewares
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddlewares> _logger;
        public CustomMiddlewares(RequestDelegate next, ILogger<CustomMiddlewares> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {

                await _next(context);
            }
            catch (UnauthorizedAccessException)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { error = "Unanthorized" });
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new { error = notFoundException.Message });
            }
            catch (BadHttpRequestException badRequest)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { error = badRequest.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected Error");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { error = "Internal Server Error" });
            }
        }
    }
}
