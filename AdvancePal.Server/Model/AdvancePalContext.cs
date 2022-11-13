namespace AdvancePal.Server.Model;

using System.Diagnostics;

using Microsoft.EntityFrameworkCore;

public class AdvancePalContext : DbContext
{
	public AdvancePalContext(DbContextOptions<AdvancePalContext> options)
		: base(options) { }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Transaction>()
			.Navigation(v => v.CreatedBy)
			.AutoInclude();
		modelBuilder.Entity<Transaction>()
			.Navigation(v => v.Lines)
			.AutoInclude();
		modelBuilder.Entity<Line>()
			.Navigation(v => v.Target)
			.AutoInclude();
	}

	public DbSet<Pal> Pal { get; set; } = null!;
	public DbSet<Line> Line { get; set; } = null!;
	public DbSet<Transaction> Transaction { get; set; } = null!;
}
