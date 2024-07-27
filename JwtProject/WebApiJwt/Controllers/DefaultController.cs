using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		[HttpGet("AddToken")]
		public IActionResult AddToken()
		{
			return Ok(new CreateToken().TokenCreate());
		}

		[HttpGet("AdminToken")]
		public IActionResult AdminToken()
		{
			return Ok(new CreateToken().TokenCreateAdmin());
		}

		[Authorize]
		[HttpGet("Test2")]
		public IActionResult Test2()
		{
			return Ok("Hoşgeldiniz");
		}

		[Authorize(Roles = "Admin,Visitor")]
		[HttpGet("Test3")]
		public IActionResult Test3()
		{
			return Ok("Token ile başarılı bir şekilde giriş yapıldı.");
		}
	}

}
