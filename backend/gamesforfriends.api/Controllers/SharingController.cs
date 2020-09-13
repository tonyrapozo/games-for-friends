namespace gamesforfriends.api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using gamesforfriends.domain.Sharing;
    using gamesforfriends.domain.Sharing.Dto;

    [ApiController]
    [Route("[controller]")]
    public class SharingController : ControllerBase
    {
        private readonly ISharingRepository sharingRepository;

        public SharingController(ISharingRepository sharingRepository)
        {
            this.sharingRepository = sharingRepository;
        }

        [HttpPost("sharings")]
        public void NewShare([FromBody] SharingDto sharingDto)
        {
            var sharing = Sharing.newSharing()
                                 .fromUser(new domain.Helper.Identifier("1").Id)
                                 .toFriend(sharingDto.FriendId)
                                 .thisGame(sharingDto.GameId)
                                 .at(DateTime.Now)
                                 .returnedAt(null);
            sharingRepository.SaveSharing(sharing);
        }

        [HttpGet("sharings")]
        public IEnumerable<Sharing> GetActiveSharings()
        {
            return sharingRepository.GetActiveSharings(new domain.Helper.Identifier("1"));
        }

        [HttpPut("sharings/return")]
        public void ReturnShare([FromBody] SharingDto sharingDto)
        {
            var sharing = sharingRepository.GetShareById(new domain.Helper.Identifier(sharingDto.Id));
            sharingRepository.SaveSharing(sharing.returnedAt(DateTime.Now));
        }
    }
}