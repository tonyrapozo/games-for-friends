namespace gamesforfriends.api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using gamesforfriends.domain.User;
    using gamesforfriends.domain.User.Dto;

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("friends")]
        public IEnumerable<Friend> GetFriends()
        {
            var user = userRepository.GetUser(new domain.Helper.Identifier("1"));
            return user.Friends;
        }

        [HttpPost("friend")]
        public void AddFriend([FromBody] FriendDto friendDto)
        {
            var user = userRepository.GetUser(new domain.Helper.Identifier("1"));
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
            var user = userRepository.GetUser(new domain.Helper.Identifier("1"));
            var friend = Friend.newFriend(friendDto.Id)
                               .called(friendDto.Name);
            user.removeFriend(friend);
            userRepository.Update(user);
        }

        [HttpGet("games")]
        public IEnumerable<Game>  GetGames()
        {
            var user = userRepository.GetUser(new domain.Helper.Identifier("1"));
            return user.Games;
        }

        [HttpPost("game")]
        public void AddGame([FromBody] GameDto gameDto)
        {
            var user = userRepository.GetUser(new domain.Helper.Identifier("1"));
            var game = Game.newGame(gameDto.Id)
                           .called(gameDto.Name)    
                           .belongsTo(user);
            user.newGame(game);
            userRepository.Update(user);
        }

        [HttpDelete("game")]
        public void RemoveGame([FromBody] GameDto gameDto)
        {
            var user = userRepository.GetUser(new domain.Helper.Identifier("1"));
            var game = Game.newGame(gameDto.Id).called(gameDto.Name);
            user.removeGame(game);
            userRepository.Update(user);
        }
    }
}