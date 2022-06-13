using WebApiBoilerPlate.API.DTOs.Requests;
using WebApiBoilerPlate.API.DTOs.Responses;
using WebApiBoilerPlate.API.Entities;

namespace WebApiBoilerPlate.API.Services.Interfaces;

    public interface IUserService
    {
        UserAuthenticateResponse Authenticate(UserAuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(UserRegisterRequest model);
        void Update(int id, UserUpdateRequest model);
        void Delete(int id);
    }

