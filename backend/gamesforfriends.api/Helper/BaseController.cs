namespace gamesforfriends.api.Helper
{
    using Microsoft.AspNetCore.Mvc;
    using gamesforfriends.domain.Helper;
    using gamesforfriends.domain.User;

    public class BaseController : ControllerBase
    {
        protected UserId GetUserId()
        {
            return new UserId(User.FindFirst("sub")?.Value);
        }
    }
}