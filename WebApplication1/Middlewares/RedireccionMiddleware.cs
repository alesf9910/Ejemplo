using WebApplication1.Services.Interfaces;

namespace WebApplication1.Middlewares
{
    public class RedireccionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAdminPanelService _service;

        public RedireccionMiddleware(RequestDelegate next, IAdminPanelService service)
        {
            _next = next;
            _service = service;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            if (!_service.CheckUrl(path))
            {
                context.Response.Redirect("/coreadmin");
            }
            else
            {
                await _next(context);
            }
        }
    }

}
