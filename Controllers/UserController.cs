using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Data;
using FirstApi.Dtos.Users;
using FirstApi.Mappers;
using FirstApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> UsersList = new List<User>();
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // Filter the response by removing the email of the user using DTOs
        [HttpGet("GetAllFiltered")]
        public IActionResult GetAllFiltered()
        {
            // TODO: Use .Select first
            var users = _context.Users.ToList().Select(s => s.ToUserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequestDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest();
            }

            var userModel = userDto.ToUserFromCreateDTO();

            _context.Users.Add(userModel);
            _context.SaveChanges();
            UsersList.Add(userModel);

            // Returns a response 201 indicating resource successfully created with a Location header pointing to the url of the new created resource.
            return CreatedAtAction(nameof(GetUserById), new { id = userModel.Id }, userModel.ToUserDto());
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userModel);
            _context.SaveChanges();
            UsersList.Remove(userModel);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userModel == null)
            {
                return NotFound();
            }

            userModel.DateCreated = updateDto.DateCreated;
            userModel.DateOfBirth = updateDto.DateOfBirth;
            userModel.Email = updateDto.Email;
            userModel.FirstName = updateDto.FirstName;
            userModel.LastName = updateDto.LastName;

            _context.SaveChanges();

            return Ok(userModel.ToUserDto());
        }
    }
}