namespace Demo.DTOs;

public sealed record Request
{
    public required string Name { get; init; }
    public uint Quantity { get; init; }
    public double Price { get; init; }
}
