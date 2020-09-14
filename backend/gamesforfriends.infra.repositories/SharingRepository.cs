namespace gamesforfriends.infra.repositories
{
    using gamesforfriends.domain.Sharing;
    using System.Collections.Generic;
    using MongoDB.Driver;
    using gamesforfriends.domain.User;

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

        public void UpdateSharing(Sharing sharing)
        {
            collection.ReplaceOne(item=>item.Id == sharing.Id, sharing);
        }

        public Sharing GetShareById(SharingId shareId)
        {
            return collection.Find(sharing => sharing.Id == shareId.Id).FirstOrDefault();
        }
        public List<Sharing> GetActiveSharings(UserId userId, int limit, int offset)
        {
            return collection.Find(sharing => sharing.User.Id == userId.Id && sharing.ReturnDate == null)
                             .Skip(offset)
                             .Limit(limit).ToList();
        }
    }
}