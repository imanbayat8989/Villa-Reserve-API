using System.Linq.Expressions;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Repository.IRepository
{
	public interface IVillaRepo : IRepo<Villa>
	{
		
		Task<Villa> UpdateAsync(Villa entity);
		
	}
}
