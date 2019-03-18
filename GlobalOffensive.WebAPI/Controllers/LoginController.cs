using GlobalOffensive.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace GlobalOffensive.WebAPI.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody]LoginViewModel login)
        {
            login.Username = login.Username.ToLower();

            bool isUsernamePasswordValid = false;

            if (login != null) isUsernamePasswordValid = login.Password == "admin" ? true : false;

            // If credentials are valid
            if (isUsernamePasswordValid)
            {
                // Create the token
                string token = createToken(login.Username);
                // Return the token
                return Json(new
                {
                    Token = token,
                    Usage = $"Authorization: {token}",
                    AlternateUsage = $"Authorization: Bearer {token}",
                    IncludeIn = "Headers"
                });
            }
            else
            {
                // If credentials are not valid
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
        }

        private string createToken(string username)
        {
            // Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            // Set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);

            // Thanks: http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            // Create an identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            // Our super secret key
            string sec = ConfigurationManager.AppSettings["Secret"].ToString();
            // Current Time
            var nbf = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(sec));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Create the jwt
            var audience = ConfigurationManager.AppSettings["Audience"].ToString();
            var issuer = ConfigurationManager.AppSettings["Issuer"].ToString();
            var token = tokenHandler.CreateJwtSecurityToken(issuer: issuer, audience: audience, subject: claimsIdentity,
                issuedAt: issuedAt, notBefore: nbf, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}