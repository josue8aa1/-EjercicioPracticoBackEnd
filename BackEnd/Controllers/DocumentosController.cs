using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentosController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		public DocumentosController(ApplicationDbContext context)
		{
			_context = context;
		}


		// POST api/<ProspectoController>
		[HttpPost]
		public async Task<ActionResult> Upload()
		{
			try
			{
				var file = Request.Form.Files[0];
				var folderName = "Documentos";
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				if (file.Length > 0)
				{
					var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var fullPath = Path.Combine(pathToSave, fileName);
					var dbPath = Path.Combine(folderName, fileName);
					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					return Ok(new { dbPath });
				}
				else
				{
					return BadRequest();
				}

				return Ok();
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

	


	}
}
