using System.ComponentModel.DataAnnotations;

namespace Villa_Web.Models.DTO
{
	public class VillaNumberUpdateDTO
	{
		public int VillaId { get; set; }
		[Required]
		public int VillaNo { get; set; }
		public string SpecialDetails { get; set; }

	}
}
