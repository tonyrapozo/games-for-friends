namespace gamesforfriends.domain.User
{
    using System;
    using gamesforfriends.domain.Helper;
    public class Friend : Identifier
    {
        protected Friend() : base() { }
        protected Friend(string friendId) : base(friendId) { }
        public static Friend newFriend() => new Friend();
        public static Friend newFriend(string friendId) => new Friend(friendId);

        public string UserId { get; protected set; }
        public Friend friendOf(User user) {
            this.UserId = user.Id;
            return this;
        }

        public string Name { get; protected set; }
        public Friend called(string name) {
            this.Name = name;
            return this;
        }

        public DateTime FriendshipDate { get; protected set; }
        public Friend friendsSince(DateTime date) {
            this.FriendshipDate = date;
            return this;
        }
    }
}