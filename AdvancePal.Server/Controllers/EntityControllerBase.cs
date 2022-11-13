namespace AdvancePal.Server.Controllers;
using System.Numerics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using AdvancePal.Server.Model;

[ApiController, Route("[controller]")]
public class EntityControllerBase<T> : ControllerBase
	where T: class, IEntity
{
	protected readonly AdvancePalContext db;

	public EntityControllerBase(AdvancePalContext db)
	{
		this.db = db;
	}

	[HttpDelete("{id}")]
	public virtual async Task DeleteAsync(int id)
	{
		await db.Set<T>()
			.AsNoTracking()
			.Where(v => v.Id.Equals(id))
			.ExecuteDeleteAsync();
	}

	[HttpGet]
	public virtual IAsyncEnumerable<T> GetAsync()
	{
		return db.Set<T>()
			.AsNoTracking()
			.AsAsyncEnumerable();
	}

	[HttpGet("{id}")]
	public virtual async Task<T> GetAsync(int id)
	{
		return await db.Set<T>()
			.AsNoTracking()
			.Where(v => v.Id.Equals(id))
			.FirstAsync();
	}

	[HttpPost]
	public virtual async Task<T> PostAsync([FromBody] T value)
	{
		await db.Set<T>().AddAsync(value);
		await db.SaveChangesAsync();
		return value;
	}
}
