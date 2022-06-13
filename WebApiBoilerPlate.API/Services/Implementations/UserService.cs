namespace WebApiBoilerPlate.API.Services.Implementations;

using System.Collections.Generic;
using WebApiBoilerPlate.API.DbContexts;
using WebApiBoilerPlate.API.DTOs.Requests;
using WebApiBoilerPlate.API.DTOs.Responses;
using WebApiBoilerPlate.API.Entities;
using WebApiBoilerPlate.API.Repositories.Interfaces;
using WebApiBoilerPlate.API.Services.Interfaces;

public class UserService : IUserService
{
   private readonly IUserRepository _userRepo;
    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    public UserAuthenticateResponse Authenticate(UserAuthenticateRequest model)
    {
        return _userRepo.Authenticate(model);
    }

    public void Delete(int id)
    {
        _userRepo.Delete(id);
    }

    public IEnumerable<User> GetAll()
    {
        return _userRepo.GetAll();
    }

    public User GetById(int id)
    {
        return _userRepo.GetById(id);
    }

    public void Register(UserRegisterRequest model)
    {
        _userRepo.Register(model);
    }

    public void Update(int id, UserUpdateRequest model)
    {
        _userRepo.Update(id,model);
    }
}

