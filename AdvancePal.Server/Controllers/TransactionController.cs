namespace AdvancePal.Server.Controllers;

using Microsoft.AspNetCore.Mvc;

using AdvancePal.Server.Model;
using Microsoft.EntityFrameworkCore;

public class TransactionController : EntityControllerBase<Transaction>
{
	public TransactionController(AdvancePalContext db)
		: base(db) { }
}
