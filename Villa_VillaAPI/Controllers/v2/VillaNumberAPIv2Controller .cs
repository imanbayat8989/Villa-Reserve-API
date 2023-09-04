using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using Villa_VillaAPI.Data;

using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.DTO;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIv2Controller : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepo _dbVillaNumber;
        private readonly IVillaRepo _dbVillaRepo;
        private readonly IMapper _mapper;
        public VillaNumberAPIv2Controller(IVillaNumberRepo dbVillaNumber, IMapper mapper, IVillaRepo villaRepo)
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _response = new();
            _dbVillaRepo = villaRepo;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1", "Value2" };
        }
    }
}

