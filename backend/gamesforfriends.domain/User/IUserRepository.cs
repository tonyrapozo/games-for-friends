namespace gamesforfriends.domain.User
{
    using gamesforfriends.domain.Helper;

    public interface IUserRepository
    {
        User GetUser(Identifier userId);
        User GetUserByEmail(string email);
        void AddUser(User user);
        void Update(User user);
        void RemoveUser(Identifier userId);
    }
}