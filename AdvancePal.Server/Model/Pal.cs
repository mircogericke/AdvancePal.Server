namespace AdvancePal.Server.Model;

public class Pal : IEntity
{
	public int Id { get; init; }
	public required string Name { get; init; }
}
