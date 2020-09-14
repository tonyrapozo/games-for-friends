namespace gamesforfriends.domain.Sharing
{
    using gamesforfriends.domain.Helper;
    using gamesforfriends.domain.User;
    using System.Collections.Generic;
    public interface ISharingRepository
    {
        List<Sharing> GetActiveSharings(UserId userId, int limit, int offset);
        Sharing GetShareById(SharingId shareId);
        void SaveSharing(Sharing sharing);
        void UpdateSharing(Sharing sharing);
    }
}