using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebStore.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _Next;

        public ErrorHandlingMiddleware(RequestDelegate Next)
        {
            _Next = Next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _Next(context);
        }
    }
}
