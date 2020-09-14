namespace gamesforfriends.domain.User
{
    using gamesforfriends.domain.Helper;
    public class UserId : Identifier
    {
        public UserId() : base() { }
        public UserId(string id) : base(id) { }
    }
}