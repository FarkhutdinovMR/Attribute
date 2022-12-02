public interface IAttribute
{
    public float Value { get; }
    AttributeType Type { get; }
    public ILevel Level { get; }
}