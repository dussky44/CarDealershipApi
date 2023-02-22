using LoginApi.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarDealershipApi.Database {
    public class UserRepository {

        private List<User> _userList;
        public UserRepository() {
            LoadJson();
        }

        private void LoadJson() {
            var items = new List<User>();
            using (StreamReader r = new StreamReader(@"Database/Data/Users.json")) {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<User>>(json);
            }
            _userList = items.ToList();
        }

        public bool CheckUser(LoginRequest request) {
            return _userList.Any(user => user.Username == request.Username && user.Password == request.Password);
        }
        public LoginResponse GetUserDetails(string username) {
            var tokenHandler = new JwtSecurityTokenHandler();
            return _userList
                .Where(user => user.Username == username)
                .Select(user => new LoginResponse {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Token = GenerateJwtToken(user.Username, user.Email)
                }).FirstOrDefault();
        }

        private string GenerateJwtToken(string username, string email) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("This is supposed to be a complex key");
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
