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

        public UserId User { get; protected set; }
        public Sharing fromUser(User user)
        {
            if (user == null)
                throw new System.ArgumentException("Object user cannot be null");
            User = new UserId(user.Id);
            return this;
        }

        public Friend Friend { get; protected set; }
        public Sharing toFriend(Friend friend)
        {
            if (friend == null)
                throw new System.ArgumentException("Object friend cannot be null");
            Friend = friend;
            return this;
        }

        public Game Game { get; protected set; }
        public Sharing thisGame(Game game)
        {
            if (game == null)
                throw new System.ArgumentException("Object game cannot be null");
            Game = game;
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