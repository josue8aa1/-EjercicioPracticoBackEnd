using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
	public class Documentos
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string NombreDocumento { get; set; }

		[Required]
		public int ProspectosId { get; set; }
	}
}
