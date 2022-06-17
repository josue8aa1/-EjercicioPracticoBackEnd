using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProspectoController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		public ProspectoController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/<ProspectoController>
		[HttpGet]
		public async Task<ActionResult> Get()
		{
			try
			{
				//var lista = await _context.Prospectos.AllAsync(x=> x.Documentos);

				var lista = await _context.Prospectos
									.Include(e => e.Documentos)
									.ToListAsync();

				return Ok(lista);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		//// GET api/<ProspectoController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		// POST api/<ProspectoController>
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] Prospectos prospecto)
		{
			try
			{
				_context.Add(prospecto);
				await _context.SaveChangesAsync();

				return Ok(prospecto);
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// PUT api/<ProspectoController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] Prospectos prospecto)
		{
			try
			{
				if (id != prospecto.Id)
				{
					return NotFound();
				}

				_context.Update(prospecto);

				await _context.SaveChangesAsync();

				return Ok(new { message = "Se modifico correctamente" });
			}
			catch (System.Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// DELETE api/<ProspectoController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				var prospecto = await _context.Prospectos.FindAsync(id);

				if (prospecto == null)
					return NotFound();

				_context.Remove(prospecto);

				await _context.SaveChangesAsync();

				return Ok(new { message = "Se elimino correctamente" });
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
