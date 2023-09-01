using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Villa_VillaAPI.Data;

using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.DTO;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Controllers
{
	[Route("api/VillaNumberAPI")]
	[ApiController]
	public class VillaNumberAPIController : ControllerBase
	{
		protected APIResponse _response;
		private readonly IVillaNumberRepo _dbVillaNumber;
		private readonly IVillaRepo _dbVillaRepo;
		private readonly IMapper _mapper;
		public VillaNumberAPIController(IVillaNumberRepo dbVillaNumber, IMapper mapper, IVillaRepo villaRepo)
        {
			_dbVillaNumber = dbVillaNumber;
			_mapper = mapper;
			this._response = new();
			_dbVillaRepo = villaRepo;
		}


        [HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<APIResponse>> GetVillas()
		{
			try
			{
				IEnumerable<VillaNumber> villaNumberList = await _dbVillaNumber.GetAllAsync(includeProperties:"Villa");
				_response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumberList);
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpGet("{id:int}",Name = "GetVillaNumber")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
		{
			try
			{
				if (id == 0)
				{
					_response.StatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
				if (villaNumber == null)
				{
					_response.StatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}
				_response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPost]
		public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
		{
			try
			{
				if (await _dbVillaNumber.GetAsync(u => u.VillaNo == createDTO.VillaNo) != null)
				{
					ModelState.AddModelError("ErrorMessages", "Villa Number already Exists!");
					return BadRequest(ModelState);
				}

				if(await _dbVillaRepo.GetAsync(u => u.Id == createDTO.VillaId) == null)
				{
					ModelState.AddModelError("ErrorMessages", "Villa Id is Invalid!");
					return BadRequest(ModelState);
				}

				if (createDTO == null)
				{
					return BadRequest(createDTO);
				}
				VillaNumber villaNumber = _mapper.Map<VillaNumber>(createDTO);

				await _dbVillaNumber.CreateAsync(villaNumber);
				_response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
				_response.StatusCode = HttpStatusCode.Created;
				return CreatedAtRoute("GetVilla", new { id = villaNumber.VillaNo }, _response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
		public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest();
				}
				var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
				if (villaNumber == null)
				{
					return NotFound();
				}
				await _dbVillaNumber.RemoveAsync(villaNumber);
				_response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPut("{id:int}", Name = "UpdateVillaNumber")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		
		public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
		{
			try
			{
				if (updateDTO == null || id != updateDTO.VillaNo)
				{

					return BadRequest();
				}
				if (await _dbVillaRepo.GetAsync(u => u.Id == updateDTO.VillaNo) == null)
				{
					ModelState.AddModelError("ErrorMessages", "Villa Id is Invalid!");
					return BadRequest(ModelState);
				}

				VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);

				await _dbVillaNumber.UpdateAsync(model);
				_response.StatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages
					= new List<string>() { ex.ToString() };
			}
			return _response;
		}
	}
}

