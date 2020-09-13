namespace gamesforfriends.api.Helper
{
    using Microsoft.AspNetCore.Mvc;
    using gamesforfriends.domain.Helper;
    
    public class BaseController : ControllerBase
    {
        protected Identifier GetUserId()
        {
            return new Identifier(User.FindFirst("sub")?.Value);
        }
    }
}