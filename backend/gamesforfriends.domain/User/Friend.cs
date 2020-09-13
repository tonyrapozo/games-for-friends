namespace gamesforfriends.domain.User
{
    using gamesforfriends.domain.Helper;
    public class Friend : Identifier
    {
        protected Friend() : base() { }
        protected Friend(string friendId) : base(friendId) { }
        public static Friend newFriend() => new Friend();
        public static Friend newFriend(string friendId) => new Friend(friendId);

        public string UserId { get; private set; }
        public Friend friendOf(User user) {
            this.UserId = user.Id;
            return this;
        }

        public string Name { get; private set; }
        public Friend called(string name) {
            this.Name = name;
            return this;
        }

        public System.DateTime FriendshipDate { get; private set; }
        public Friend friendsSince(System.DateTime date) {
            this.FriendshipDate = date;
            return this;
        }
    }
}