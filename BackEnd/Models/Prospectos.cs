using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
	public class Prospectos
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Nombre { get; set; }
		[Required]
		public string PrimerApellido { get; set; }

		public string SegundoApellido { get; set; }

		[Required]
		public string Calle { get; set; }

		[Required]
		public int Numero { get; set; }
		[Required]
		public int CodigoPostal { get; set; }
		[Required]
		public int Telefono { get; set; }
		[Required]
		public string RFC { get; set; }

		public string Estatus { get; set; }
		[Required]
		public string Observaciones { get; set; }

		public virtual ICollection<Documentos> Documentos { get; set; }
	}
}
