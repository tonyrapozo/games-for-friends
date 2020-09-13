namespace gamesforfriends.api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using gamesforfriends.domain.User;
    using gamesforfriends.domain.User.Dto;
    using gamesforfriends.api.Helper;

    [ApiController]
    [Route("user")]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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
            var friend = Friend.newFriend(friendDto.Id)
                               .called(friendDto.Name)
                               .friendsSince(DateTime.Now)
                               .friendOf(user);
            user.newFriend(friend);
            userRepository.Update(user);
        }

        [HttpDelete("friend")]
        public void RemoveFriend([FromBody] FriendDto friendDto)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var friend = Friend.newFriend(friendDto.Id)
                               .called(friendDto.Name);
            user.removeFriend(friend);
            userRepository.Update(user);
        }

        [HttpGet("games")]
        public IEnumerable<Game>  GetGames()
        {
            var user = userRepository.GetUser(base.GetUserId());
            return user.Games;
        }

        [HttpPost("game")]
        public void AddGame([FromBody] GameDto gameDto)
        {
            Console.WriteLine(gameDto.Name);
            var user = userRepository.GetUser(base.GetUserId());
            var game = Game.newGame()
                           .called(gameDto.Name)    
                           .belongsTo(user);
            user.newGame(game);
            userRepository.Update(user);
        }

        [HttpDelete("game")]
        public void RemoveGame([FromBody] GameDto gameDto)
        {
            var user = userRepository.GetUser(base.GetUserId());
            var game = Game.newGame().called(gameDto.Name);
            user.removeGame(game);
            userRepository.Update(user);
        }
    }
}