namespace WebApiBoilerPlate.API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBoilerPlate.API.Helpers.Authorization;

[Authorize]
[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{


}

