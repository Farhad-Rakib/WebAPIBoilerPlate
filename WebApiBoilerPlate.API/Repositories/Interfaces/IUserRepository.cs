namespace WebApiBoilerPlate.API.Repositories.Interfaces;
using WebApiBoilerPlate.API.DTOs.Requests;
using WebApiBoilerPlate.API.DTOs.Responses;
using WebApiBoilerPlate.API.Entities;
using WebApiBoilerPlate.API.Services.Interfaces;

public interface IUserRepository
{
    UserAuthenticateResponse Authenticate(UserAuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(UserRegisterRequest model);
    void Update(int id, UserUpdateRequest model);
    void Delete(int id);
}

