using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace SM.Infraestructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequesObjetResult(context.ModelState);
                return;

            }
            await next();
        }
    }
}
