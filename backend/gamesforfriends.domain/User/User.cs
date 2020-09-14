namespace gamesforfriends.domain.User
{
    using System.Collections.Generic;
    using gamesforfriends.domain.Helper;

    public class User : Identifier
    {
        protected User() : base() 
        {
            Friends = new List<Friend>();
            Games = new List<Game>();
        }

        protected User(string userId) : base(userId) 
        { 
            Friends = new List<Friend>();
            Games = new List<Game>();
        }

        public static User newUser(){
            return new User();
        }

        public static User newUser(string userId){
            return new User(userId);
        }

        public string Name { get; protected set; }
        public User called(string name){
            Name = name;
            return this;
        }

        public string Email { get; protected set; }
        public User withEmail(string email){
            Email = email;
            return this;
        }

        public string Password { get; protected set; }
        public User withPassword(string password){
            Password = password;
            return this;
        }

        public List<Friend> Friends { get; protected set; }
        public User newFriend(Friend friend)
        {
            if (Friends.Find(item => item.Id == friend.Id) != null)
                throw new System.ArgumentException($@"{friend.Name} already is your friend.");

            friend.friendOf(this);
            Friends.Add(friend);
            return this;
        }

        public User updateFriendData(Friend friend)
        {
            var myFriend = Friends.Find(item => item.Id == friend.Id);
            if (Friends.Find(item => item.Id == friend.Id) == null)
                throw new System.ArgumentException($@"The friend {friend.Name} with the id {friend.Id} is not your friend.");

            myFriend.called(friend.Name);
            Friends.RemoveAll(item => item.Id == myFriend.Id);
            Friends.Add(myFriend);
            return this;
        }

        public User removeFriend(Friend friend)
        {
            if (Friends.Find(item => item.Id == friend.Id) == null)
                throw new System.ArgumentException($@"The friend {friend.Name} with the id {friend.Id} is not your friend.");

            Friends.RemoveAll(item=>item.Id == friend.Id);
            
            return this;
        }

        public List<Game> Games { get; protected set; }
        public User newGame(Game game)
        {
            if (Games.Find(item => item.Id == game.Id) != null)
                throw new System.ArgumentException($@"You already have the game {game.Name} with id {game.Id}.");

            Games.Add(game);
            return this;
        }
        public User removeGame(Game game)
        {
            if (Games.Find(item => item.Id == game.Id) == null)
                throw new System.ArgumentException($@"The game {game.Name} with id {game.Id} does not belongs to your collection!");

            Games.RemoveAll(item=>item.Id == game.Id);
            return this;
        }
    }
}