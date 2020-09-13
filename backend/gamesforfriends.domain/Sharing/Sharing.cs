namespace gamesforfriends.domain.Sharing
{
    using gamesforfriends.domain.Helper;
    using gamesforfriends.domain.User;

    public class Sharing : Identifier
    {
        protected Sharing() : base() { }

        protected Sharing(string sharingId) : base(sharingId) { }

        public static Sharing newSharing() => new Sharing();

        public static Sharing newSharing(string sharingId) => new Sharing(sharingId);

        public Identifier User { get; protected set; }
        public Sharing fromUser(User user)
        {
            this.User = new Identifier(user.Id);
            return this;
        }

        public Friend Friend { get; protected set; }
        public Sharing toFriend(Friend friend)
        {
            this.Friend = friend;
            return this;
        }

        public Game Game { get; protected set; }
        public Sharing thisGame(Game game)
        {
            this.Game = game;
            return this;
        }

        public System.DateTime SharingDate { get; protected set; }
        public Sharing at(System.DateTime sharingDate)
        {
            this.SharingDate = sharingDate;
            return this;
        }

        public System.DateTime? ReturnDate { get; protected set; }
        public Sharing returnedAt(System.DateTime? returnDate)
        {
            this.ReturnDate = returnDate;
            return this;
        }
    }
}