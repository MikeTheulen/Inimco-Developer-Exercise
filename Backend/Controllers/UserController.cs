using Backend.Context;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext context;
        private readonly IUserRepository repository;

        public UserController(UserContext context, IUserRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var temp = await repository.Get(context, user);
            temp = temp != null ? user : await repository.Add(context, user);

            var name = $"{temp.FirstName} {temp.LastName}";

            Console.WriteLine($"");
            repository.HowManyVowels(name);
            repository.HowManyConstenants(name);
            Console.WriteLine($"The firstname + last name entered: {name}");
            repository.ReverseName(name);
            repository.JSONFormat(user);

            return temp == null ? NotFound() : Ok(temp);
        }
    }
}
