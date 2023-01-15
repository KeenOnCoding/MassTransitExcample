namespace Contracts
{
    public record Order()
    {
        public Guid Id { get; set; }
        public string? Greeting { get; set; }
    }
}