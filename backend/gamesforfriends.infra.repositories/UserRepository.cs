namespace gamesforfriends.infra.repositories
{
    using gamesforfriends.domain.User;
    using gamesforfriends.domain.Helper;
    using MongoDB.Driver;
    using System;

    public class UserRepository : IUserRepository
    {
        private IMongoCollection<User> collection;
        public UserRepository(IMongoDatabase mongoDatabase)
        {
            this.collection = mongoDatabase.GetCollection<User>("User");
        }

        public User GetUser(UserId userId)
        {
            return collection.Find(filter => filter.Id == userId.Id).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return collection.Find(filter => filter.Email == email).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            collection.InsertOneAsync(user).Wait();
        }

        public void Update(User user)
        {
            collection.ReplaceOne(filter => filter.Id == user.Id, user);
        }

        public void RemoveUser(UserId userId)
        {
            collection.DeleteOne(filter => filter.Id == userId.Id);
        }
    }
}