namespace gamesforfriends.infra.repositories
{
    using gamesforfriends.domain.Sharing;
    using gamesforfriends.domain.Helper;
    using System.Collections.Generic;
    using MongoDB.Driver;

    public class SharingRepository : ISharingRepository
    {
        private IMongoCollection<Sharing> collection;
        public SharingRepository(IMongoDatabase mongoDatabase)
        {
            collection = mongoDatabase.GetCollection<Sharing>("Sharing");
        }

        public void SaveSharing(Sharing sharing)
        {
            collection.InsertOne(sharing);
        }

        public Sharing GetShareById(Identifier shareId)
        {
            return collection.Find(sharing => sharing.Id == shareId.Id).FirstOrDefault();
        }

        public List<Sharing> GetActiveSharings(Identifier userId)
        {
            return collection.Find(sharing => sharing.User.Id == userId.Id && sharing.ReturnDate == null).ToList();
        }
    }
}