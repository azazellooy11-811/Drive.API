using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Drive.Core.Models;
using Drive.Database;
using Drive.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Drive.Core.Services
{
    public interface IUserService
    {
        void Register(RegistrationRequest users);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        List<User> GetAll();
        Task<User> GetById(long id);
        Task<bool> Update(long clientId, UserUpdateModel user);
        Task<bool> AddErrorQuestion(long clientId, long questionId);
    }

    public class UserService : IUserService
    {
        private readonly DriveContext _dbContext;

        public UserService(DriveContext dbContext)
        {
            _dbContext = dbContext;
        }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        public void Register(RegistrationRequest users)
        {
            var existUser = _dbContext.Users.FirstOrDefault(x => x.Username == users.Username);
            if (existUser != null) throw new InvalidOperationException();

            var user = new User()
            {
                FirstName = users.FirstName,
                LastName = users.LastName,
                Username = users.Username,
                City = users.City,
                DrivingSchool = users.DrivingSchool,
                PasswordHash = users.PasswordHash
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _dbContext.Users.SingleOrDefault(x =>
                x.Username == model.Username && x.PasswordHash == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }


        public List<User> GetAll()
        {
            var users = _dbContext.Users.OrderBy(x => x.Points).ToList();
            return users;
        }

        public async Task<User> GetById(long id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(
                "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id.ToString())}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> Update(long clientId, UserUpdateModel user)
        {
            var client = await _dbContext.Users.FirstOrDefaultAsync(x =>
                x.Id == clientId);

            if (user.FirstName != null)
                client.FirstName = user.FirstName;
            if (user.LastName != null)
                client.LastName = user.LastName;
            if (user.Username != null)
                client.Username = user.Username;
            if (user.City != null)
                client.City = user.City;
            if (user.DrivingSchool != null)
                client.DrivingSchool = user.DrivingSchool;
            if (user.PasswordHash != null)
                client.PasswordHash = user.PasswordHash;
            if (user.Points != 0)
                client.Points = user.Points;
            if (user.ErrorQuestion != null)
                client.ErrorQuestion = user.ErrorQuestion;

            _dbContext.Users.Update(client);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddErrorQuestion(long clientId, long questionId)
        {
            var client = await _dbContext.Users.Include(x => x.ErrorQuestion)
                .FirstOrDefaultAsync(x => x.Id == clientId);

            var errorQuestion = await _dbContext.Questions
                .FirstOrDefaultAsync(x => x.Id == questionId);


            client.ErrorQuestion.Add(errorQuestion);
           
            _dbContext.Users.Update(client);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}