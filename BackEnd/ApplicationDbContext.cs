using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Prospectos> Prospectos { get; set; }
		public DbSet<Documentos> Documentos { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
	}
}
