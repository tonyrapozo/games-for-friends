namespace gamesforfriends.api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using gamesforfriends.domain.User;
    using gamesforfriends.domain.User.Dto;
    using gamesforfriends.api.Helper;
    using gamesforfriends.domain.Sharing;
    using System.Linq;

    [ApiController]
    [Route("user")]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;
        private readonly ISharingRepository sharingRepository;
        public UserController(IUserRepository userRepository, ISharingRepository sharingRepository)
        {
            this.userRepository = userRepository;
            this.sharingRepository = sharingRepository;
        }

        [HttpGet("friends")]
        public IEnumerable<Friend> GetFriends()
        {
            var user = userRepository.GetUser(base.GetUserId());
            return user.Friends;
        }

        [HttpPost("friend")]
        public void AddFriend([FromBody] FriendDto friendDto)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var friend = Friend.newFriend()
                               .called(friendDto.Name)
                               .friendsSince(DateTime.Now)
                               .friendOf(user);
            user.newFriend(friend);
            userRepository.Update(user);
        }

        [HttpPut("friend")]
        public void UpdateFriend([FromBody] FriendDto friendDto)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var friend = Friend.newFriend(friendDto.Id)
                               .called(friendDto.Name)
                               .friendOf(user);
            user.updateFriendData(friend);
            userRepository.Update(user);
        }

        [HttpDelete("friend/{friendId}")]
        public void RemoveFriend(string friendId)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var friend = Friend.newFriend(friendId);
            userRepository.Update(user.removeFriend(friend));
        }

        [HttpGet("games")]
        public IEnumerable<Game> GetGames()
        {
            var user = userRepository.GetUser(base.GetUserId());
            return user.Games;
        }

        [HttpGet("games/free")]
        public IEnumerable<Game> GetFreeGames()
        {
            var user = userRepository.GetUser(base.GetUserId());
            var sharings = sharingRepository.GetActiveSharings(base.GetUserId());
            return user.Games.Where(game => sharings.Find(sharing => sharing.Game.Id == game.Id) == null);
        }

        [HttpPost("game")]
        public void AddGame([FromBody] GameDto gameDto)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var game = Game.newGame()
                           .called(gameDto.Name)   
                           .withCoverImage(gameDto.Image) 
                           .belongsTo(user);
            userRepository.Update(user.newGame(game));
        }

        [HttpDelete("game/{gameid}")]
        public void RemoveGame(string gameId)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var game = Game.newGame(gameId);
            userRepository.Update(user.removeGame(game));
        }
    }
}