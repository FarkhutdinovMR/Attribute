public interface ILevel
{
    uint Value { get; }
    uint MaxValue { get; }
    void LevelUp();
}