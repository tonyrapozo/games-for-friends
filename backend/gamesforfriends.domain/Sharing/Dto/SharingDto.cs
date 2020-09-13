namespace gamesforfriends.domain.Sharing.Dto
{
    using System;
    public class SharingDto
    {
        public string Id { get; set; }
        public string FriendId { get; set; }
        public string GameId { get; set; }
        public DateTime SharingDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}