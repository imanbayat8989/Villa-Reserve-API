using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
	public class VillaRepo : Repo<Villa>, IVillaRepo
	{
		private readonly ApplicationDbContext _db;
		public VillaRepo(ApplicationDbContext db): base(db) 
		{ 
			_db = db;
		}

		
		public async Task<Villa> UpdateAsync(Villa entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_db.villas.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}
	}
}
