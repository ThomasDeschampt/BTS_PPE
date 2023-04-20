using System;
using System.Drawing.Text;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Http;
using Model;
using ORM_PPE_SLAM;



namespace Back_GSB.Controllers
{
    public class TokenController : ApiController
    {

        private data_model db = new data_model(); 

        //api/Token
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] token_request login)
        {
            //Recherche de l'utilisateur dans la base de données
           user user = GetUser(login);


            var loginResponse = new token_reponse { };
            token_request loginrequest = new token_request { };
            loginrequest.pseudo = login.pseudo;
            loginrequest.mdp = login.mdp;
 

            IHttpActionResult response;
            bool isUsernamePasswordValid = false;


            if (login != null && user != null)
                isUsernamePasswordValid = (loginrequest.pseudo == user.pseudo_user && loginrequest.mdp == user.mdp_user)? true : false;

            if (isUsernamePasswordValid)
            {
                string token = createToken(loginrequest.pseudo);

                StoreToken(token);
                return Ok<string>(token);
            }
            else
            {
                loginResponse.ReponseMsg.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(loginResponse.ReponseMsg);
                return response;
            }
        }

        private user GetUser(token_request login)
        {
            user user = null;

            try
            {
                user = db.users.Where(U => U.pseudo_user.Equals(login.pseudo) && U.mdp_user.Equals(login.mdp)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
            return user;
        }


        private string createToken(string username)
        {
            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(10);

            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            const string sec = "IciCaHashLesTokens";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "https://localhost:44345", audience: "https://localhost:44345",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

 

        private void StoreToken(string token)
        {
            string fileName = @"C:\tmp\token.txt";

            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))
                File.Delete(fileName);

            // Create a new file     
            using (FileStream fs = File.Create(fileName))
            {

                // Add some text to file    
                Byte[] title = new UTF8Encoding(true).GetBytes(token);
                fs.Write(title, 0, title.Length);

            }

        }
    }
}