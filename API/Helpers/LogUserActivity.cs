using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }

            int userId = resultContext.HttpContext.User.GetUserId();
            IUnitOfWork uow = resultContext.HttpContext.RequestServices.GetService<IUnitOfWork>();
            AppUser user = await uow.UserRepository.GetUserByIdAsync(userId);
            user.LastActive = DateTime.UtcNow;
            _ = await uow.Complete();
        }
    }
}
