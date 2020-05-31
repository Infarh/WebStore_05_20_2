using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebStore.Infrastructure.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _Next;

        public CultureMiddleware(RequestDelegate Next) => _Next = Next;

        public async Task Invoke(HttpContext Context)
        {
            var lang = Context.Request.Query["lang"].ToString();
            if(!string.IsNullOrWhiteSpace(lang))
                try
                {
                    CultureInfo.CurrentCulture =
                        CultureInfo.CurrentUICulture =
                            new CultureInfo(lang);
                }
                catch (CultureNotFoundException )
                {
                    
                }

            await _Next(Context);
        }
    }
}
