namespace AdvancePal.Server.Model;

using System.ComponentModel;

using Microsoft.EntityFrameworkCore;

[Owned]
public class Line : IEntity
{
	public int Id { get; init; }
	public Pal? Target { get; init; }
	public int TargetId { get; init; }
	public required decimal Amount { get; init; }
}
