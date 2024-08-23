using AutoMapper;
using MessangerBackend.Core.Interfaces;
using MessangerBackend.DTOs;
using MessangerBackend.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MessangerBackend.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : Controller
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> RegisterUser(CreateUserRequest request)
    {
        var userDb = await _userService.Register(request.Nickname, request.Password);

        return Created("user", _mapper.Map<UserDTO>(userDb));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromQuery] int page, [FromQuery] int size)
    {
        var users = _userService.GetUsers(page, size);
        return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUserById(int id)
    {
        return Ok(_mapper.Map<UserDTO>(await _userService.GetUserById(id)));
    }

    [HttpGet("search/{name}")]
    public ActionResult<IEnumerable<UserDTO>> SearchUsers(string name)
    {
        var users = _userService.SearchUsers(name);
        return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
    }
}