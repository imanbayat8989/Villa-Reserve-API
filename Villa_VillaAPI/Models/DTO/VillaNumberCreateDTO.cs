﻿using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models.DTO
{
	public class VillaNumberCreateDTO
	{

		[Required]
		public int VillaNo { get; set; }
		[Required]
		public int VillaId { get; set; }
		public string SpecialDetails { get; set; }


	}
}