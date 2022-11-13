namespace AdvancePal.Server.Controllers;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AdvancePal.Server.Model;
using Microsoft.EntityFrameworkCore;

public class PalController : EntityControllerBase<Pal>
{
	public PalController(AdvancePalContext db)
		: base(db) { }

	[NonAction]
	public override Task DeleteAsync(int id) => base.DeleteAsync(id);

	[HttpGet, Route("ByName")]
	public virtual async Task<Pal> ByNameAsync([FromQuery] string name)
	{
		return await db.Pal
			.AsNoTracking()
			.Where(x => x.Name.Contains(name))
			.FirstAsync();
	}
}
