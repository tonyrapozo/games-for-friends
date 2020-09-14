namespace gamesforfriends.domain.User
{
    using gamesforfriends.domain.Helper;
    public class Game : Identifier
    {
        protected Game() : base() { }

        protected Game(string gameId) : base(gameId) { }

        public static Game newGame() => new Game();

        public static Game newGame(string gameId) => new Game(gameId);

        public string UserId { get; protected set; }
        public Game belongsTo(User user) {
            this.UserId = user.Id;
            return this;
        }

        public string Image { get; protected set; }
        public Game withCoverImage(string image) {
            this.Image = image;
            return this;
        }

        public string Name { get; protected set; }
        public Game called(string name) {
            this.Name = name;
            return this;
        }
    }
}