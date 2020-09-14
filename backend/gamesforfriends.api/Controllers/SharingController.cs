namespace gamesforfriends.api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using gamesforfriends.domain.Sharing;
    using gamesforfriends.domain.Sharing.Dto;
    using gamesforfriends.domain.User;
    using gamesforfriends.api.Helper;

    [ApiController]
    [Route("sharings")]
    [Authorize]
    public class SharingController : BaseController
    {
        private readonly ISharingRepository sharingRepository;
        private readonly IUserRepository userRepository;
        public SharingController(IUserRepository userRepository, ISharingRepository sharingRepository)
        {
            this.userRepository = userRepository;
            this.sharingRepository = sharingRepository;
        }

        [HttpPost]
        public void NewShare([FromBody] SharingDto sharingDto)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var friend = user.Friends.Find(friend => friend.Id == sharingDto.FriendId);
            var game = user.Games.Find(game => game.Id == sharingDto.GameId);

            var sharing = Sharing.newSharing()
                                 .fromUser(user)
                                 .toFriend(friend)
                                 .thisGame(game)
                                 .at(DateTime.Now)
                                 .returnedAt(null);

            sharingRepository.SaveSharing(sharing);
        }

        [HttpGet]
        public IEnumerable<Sharing> GetActiveSharings()
        {
            return sharingRepository.GetActiveSharings(base.GetUserId());
        }

        [HttpDelete("return/{sharingId}")]
        public void ReturnShare(string sharingId)
        {
            var sharing = sharingRepository.GetShareById(new domain.Helper.Identifier(sharingId));
            sharingRepository.UpdateSharing(sharing.returnedAt(DateTime.Now));
        }
    }
}