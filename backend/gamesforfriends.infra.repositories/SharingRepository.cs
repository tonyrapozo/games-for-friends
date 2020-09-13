namespace gamesforfriends.infra.repositories
{
    using gamesforfriends.domain.Sharing;
    using gamesforfriends.domain.Helper;
    using System.Collections.Generic;

    public class SharingRepository : ISharingRepository
    {
        public Sharing SaveSharing(Sharing sharing)
        {
            return sharing;
        }

        public Sharing GetShareById(Identifier shareId){
            return null;
        }

        public List<Sharing> GetActiveSharings(Identifier userId)
        {
            return null;
        }
    }
}