using FinanceProject.Interfaces;
using FinanceProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FinanceProject.Services
{
    public class TokenService:ITokenService

    {

        private readonly IConfiguration _configuration;

        private readonly SymmetricSecurityKey _symmetrickey;
        public TokenService(IConfiguration config)

        {
            _configuration = config;
            _symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));


        }

        public string CreateToken(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),

                new Claim (JwtRegisteredClaimNames.GivenName,user.UserName)


            };

           var  creds= new SigningCredentials(_symmetrickey,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescreptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["JWT:Issuer"],
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Audience = _configuration["JWT:Audience"]
            };

            var tokenhandler = new JwtSecurityTokenHandler();

            var token = tokenhandler.CreateToken(tokenDescreptor);

            return tokenhandler.WriteToken(token);
        }
    }
    
}
