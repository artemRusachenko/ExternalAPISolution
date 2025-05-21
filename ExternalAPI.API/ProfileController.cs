using Microsoft.AspNetCore.Mvc;

namespace ExternalAPI.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        [HttpGet("{login}")]
        public IActionResult GetProfile(string login)
        {
            if (login.ToLower() == "is-31fiot-23-080")
            {
                return Ok(new
                {
                    LastName = "Русаченко",
                    FirstName = "Артем",
                    Course = 2,
                    Group = "ІС-31"
                });
            }

            return NotFound(new { message = "Користувача не знайдено" });
        }
    }
}
