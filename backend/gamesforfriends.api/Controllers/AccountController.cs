namespace gamesforfriends.api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System;
    using gamesforfriends.domain.User;
    using gamesforfriends.api.Helper;
    using gamesforfriends.api.Services;
    using gamesforfriends.infra.Extensions;
    using gamesforfriends.domain.User.Dto;


    [ApiController]
    [Route("account")]
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IUserRepository userRepository;

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("new")]
        public void NewUser([FromBody] UserDto userDto)
        {
            var user = domain.User.User.newUser()
                                       .called(userDto.Name)
                                       .withEmail(userDto.Email)
                                       .withPassword(userDto.Password.Md5());
            userRepository.AddUser(user);
        }

        [HttpPost("login")]
        public ActionResult<dynamic> Login([FromBody] UserDto userDto)
        {
            var user = userRepository.GetUserByEmail(userDto.Email);
            
            if (user.Password != userDto.Password.Md5())
                throw new Exception("Invalid user or password");

            var token = AccountService.GenerateToken(user);

            return new {
                name = user.Name,
                token = token
            };
        }
    }
}