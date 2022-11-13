namespace AdvancePal.Server.Model;

using System.ComponentModel.DataAnnotations;

public class Transaction : IEntity
{
	public int Id { get; init; }
	public required string Label { get; init; }
	[MinLength(1)]
	public required List<Line> Lines { get; init; }
	public Pal? CreatedBy { get; init; }
	public int CreatedById { get; init; }
	public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
