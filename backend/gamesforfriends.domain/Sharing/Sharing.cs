namespace gamesforfriends.domain.Sharing
{
    using System.Collections.Generic;
    using gamesforfriends.domain.Helper;
    using gamesforfriends.domain.User;

    public class Sharing : Identifier
    {
        protected Sharing() : base() { }

        protected Sharing(string sharingId) : base(sharingId) { }

        public static Sharing newSharing() => new Sharing();

        public static Sharing newSharing(string sharingId) => new Sharing(sharingId);

        public string UserId { get; private set; }
        public Sharing fromUser(string userId)
        {
            this.UserId = userId;
            return this;
        }

        public string FriendId { get; private set; }
        public Sharing toFriend(string friendId)
        {
            this.FriendId = friendId;
            return this;
        }

        public string GameId { get; private set; }
        public Sharing thisGame(string gameId)
        {
            this.GameId = gameId;
            return this;
        }

        public System.DateTime SharingDate { get; private set; }
        public Sharing at(System.DateTime sharingDate)
        {
            this.SharingDate = sharingDate;
            return this;
        }

        public System.DateTime? ReturnDate { get; private set; }
        public Sharing returnedAt(System.DateTime? returnDate)
        {
            this.ReturnDate = returnDate;
            return this;
        }
    }
}