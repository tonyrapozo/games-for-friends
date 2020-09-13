namespace gamesforfriends.api.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using gamesforfriends.api.Helper;
    using gamesforfriends.domain.User;
    using Microsoft.IdentityModel.Tokens;

    public static class AccountService
    {
        public static string GenerateToken(User user)
        {
            var t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            var payload = new JwtPayload
            {
                { "sub", user.Id },
                { "userName", user.Name },
                { "iat", (int)t.TotalSeconds },
                { "exp", (int)t.TotalSeconds + 86400 }
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }
    }
}