using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PorjekatDataAccsess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace api.core
{
    public class jwtManager
    {

        private readonly ProjekatDbContext _context;

        public jwtManager(ProjekatDbContext context)
        {
            _context = context;
        }

        public string MakeToken(string username, string password)
        {
            var user = _context.user.Include(u => u.userUseCase).FirstOrDefault(x => x.email == username && x.password == password);
            if (user == null)
            {
                return null;
            }
            var actor = new jwtActor
            {
                id = user.id,
                AllowedUseCases = user.userUseCase.Select(x => x.UseCaseId),
                Indetity = user.email,

            };

            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(1000),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
