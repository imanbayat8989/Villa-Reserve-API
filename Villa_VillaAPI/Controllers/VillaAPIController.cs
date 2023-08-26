using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Villa_VillaAPI.Data;

using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.DTO;

namespace Villa_VillaAPI.Controllers
{
	[Route("api/VillaAPI")]
	[ApiController]
	public class VillaAPIController : ControllerBase
	{
		

		public VillaAPIController()
        {
			
		}


        [HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
		
			return Ok(VillaStore.VillaList);
		}
		[HttpGet("{id:int}",Name ="GetVilla")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<VillaDTO> GetVilla(int id)
		{
			if (id == 0)
			{
				
				return BadRequest();
			}
			var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
			if (villa == null)
			{
				return NotFound();
			}

			return Ok(villa);
		}

		[HttpPost]
		public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
		{
			//if (!ModelState.IsValid)
			//{
			//	return BadRequest(ModelState);
			//}
			if(VillaStore.VillaList.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower())!=null) 
			{
				ModelState.AddModelError("CustomError", "Villa already Exists!");
				return BadRequest(ModelState);
			}

			if (villaDTO == null)
			{
				return BadRequest(villaDTO);
			}
			if (villaDTO.Id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			villaDTO.Id = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
			VillaStore.VillaList.Add(villaDTO);

			return CreatedAtRoute("GetVilla",new {id = villaDTO.Id} ,villaDTO);
		}

		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpDelete("{id:int}", Name ="DeleteVilla")]
		public IActionResult DeleteVilla(int id)
		{
			if(id == 0)
			{
				return BadRequest();
			}
			var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id ==id);
			if(villa == null)
			{
				return NotFound();
			}
			VillaStore.VillaList.Remove(villa);
			return NoContent();
		}

		[HttpPut("{id:int}", Name = "UpdateVilla")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		
		public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
		{
			if(villaDTO == null || id != villaDTO.Id)
			{
				
				return BadRequest();
			}
			var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id ==id);
			villa.Name = villaDTO.Name;
			villa.meter = villaDTO.meter;
			villa.Occupancy = villaDTO.Occupancy;

			return NoContent();
		}

		[HttpPatch("{id:int}", Name ="UpdatePartialVilla")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult UpdatePArtialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
		{
			if(patchDTO == null || id == 0)
			{
				return BadRequest();
			}
			var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id ==id);
			if (villa == null)
			{
				return BadRequest();
			}
			patchDTO.ApplyTo(villa, ModelState);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return NoContent();
		}
	}
}

