using System.Linq.Expressions;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Repository.IRepository
{
	public interface IVillaRepo
	{
		Task<List<Villa>> GetAllAsync(Expression<Func<Villa,bool>> filter = null);
		Task<Villa> GetAsync(Expression<Func<Villa,bool>> filter = null, bool tracked=true);
		Task CreateAsync(Villa entity);
		Task UpdateAsync(Villa entity);
		Task RemoveAsync(Villa entity);
		Task SaveAsync();
	}
}
