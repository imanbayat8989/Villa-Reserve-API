using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
	public class VillaNumberRepo : Repo<VillaNumber>, IVillaNumberRepo
	{
		private readonly ApplicationDbContext _db;
		public VillaNumberRepo(ApplicationDbContext db): base(db) 
		{ 
			_db = db;
		}

		
		public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
		{
			entity.UpdatedDate = DateTime.Now;
			_db.villaNumbers.Update(entity);
			await _db.SaveChangesAsync();
			return entity;
		}
	}
}
