namespace gamesforfriends.infra.repositories
{
    using System;
    using gamesforfriends.domain.User;
    using gamesforfriends.domain.Helper;

    public class UserRepository : IUserRepository
    {
        public User GetUser(Identifier userId)
        {
            return User.newUser();
        }

        public User AddUser(User user)
        {
            return User.newUser();
        }

        public User Update(User user)
        {
            return User.newUser();
        }

        public User RemoveUser(Identifier userId)
        {
            return User.newUser();
        }
    }
}