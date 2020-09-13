namespace gamesforfriends.domain.User
{
    using System.Collections.Generic;
    using gamesforfriends.domain.Helper;

    public interface IUserRepository
    {
        User GetUser(Identifier userId);
        User AddUser(User user);
        User Update(User user);
        User RemoveUser(Identifier userId);
    }
}