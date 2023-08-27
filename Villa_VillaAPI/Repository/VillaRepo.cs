using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
	public class VillaRepo : IVillaRepo
	{
		private readonly ApplicationDbContext _db;
		public VillaRepo(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(Villa entity)
		{
			await _db.villas.AddAsync(entity);
			await SaveAsync();
		}

		public async Task<Villa> GetAsync(Expression<Func<Villa,bool>> filter = null, bool tracked = true)
		{
			IQueryable<Villa> query = _db.villas;
			if (!tracked)
			{
				query = query.AsNoTracking();
			}
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.FirstOrDefaultAsync();
		}

		public async Task<List<Villa>> GetAllAsync(Expression<Func<Villa,bool>> filter = null)
		{
			IQueryable<Villa> query = _db.villas;
			if (filter != null) 
			{
				query = query.Where(filter);
			}
			return await query.ToListAsync();
		}

		public async Task RemoveAsync(Villa entity)
		{
			_db.villas.Remove(entity);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await _db.SaveChangesAsync();
		}

		public async Task UpdateAsync(Villa entity)
		{
			_db.villas.Update(entity);
			await SaveAsync();
		}
	}
}
