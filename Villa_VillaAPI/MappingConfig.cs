using AutoMapper;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.DTO;

namespace Villa_VillaAPI
{
	public class MappingConfig : Profile
	{
		public MappingConfig() 
		{
			CreateMap<Villa, VillaDTO>();
			CreateMap<VillaDTO, Villa>();

			CreateMap<Villa, VillaCreateDTO>().ReverseMap();
			CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
		}
	}
}
