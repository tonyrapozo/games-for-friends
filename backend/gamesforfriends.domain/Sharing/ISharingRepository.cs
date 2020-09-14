namespace gamesforfriends.domain.Sharing
{
    using gamesforfriends.domain.Helper;
    using System.Collections.Generic;
    public interface ISharingRepository
    {
        List<Sharing> GetActiveSharings(Identifier userId);
        Sharing GetShareById(Identifier shareId);
        void SaveSharing(Sharing sharing);
        void UpdateSharing(Sharing sharing);
    }
}