namespace WebApiBoilerPlate.API.Repositories.Repositories;

using System.Collections.Generic;
using WebApiBoilerPlate.API.DbContexts;
using WebApiBoilerPlate.API.DTOs.Requests;
using WebApiBoilerPlate.API.DTOs.Responses;
using WebApiBoilerPlate.API.Entities;
using WebApiBoilerPlate.API.Repositories.Interfaces;
using AutoMapper;
using WebApiBoilerPlate.API.Helpers.Authorization;
using BCrypt.Net;
using WebApiBoilerPlate.API.Helpers;

public class UserRepository : IUserRepository
{
    private ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private IJwtUtils _jwtUtils;

    public UserRepository(ApplicationDbContext context,IJwtUtils jwtUtils,IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }
    public UserAuthenticateResponse Authenticate(UserAuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful
        var response = _mapper.Map<UserAuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }

    public void Delete(int id)
    {
        var user = getUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return getUser(id);
    }

    public void Register(UserRegisterRequest model)
    {
        if (_context.Users.Any(x => x.Username == model.Username))
            throw new AppException("Username '" + model.Username + "' is already taken");

        // map model to new user object
        var user = _mapper.Map<User>(model);

        // hash password
        user.PasswordHash = BCrypt.HashPassword(model.Password);

        // save user
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UserUpdateRequest model)
    {
        var user = getUser(id);

        // validate
        if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
            throw new AppException("Username '" + model.Username + "' is already taken");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = BCrypt.HashPassword(model.Password);

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }
    private User getUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}

