using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models.DTO
{
	public class VillaDTO
	{
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
		public string Details { get; set; }
		[Required]
		public string Rate { get; set; }
		public int Occupancy { get; set; }
        public int meter { get; set; }
		public string ImageUrl { get; set; }
		public string Amenity { get; set; }

	}
}
