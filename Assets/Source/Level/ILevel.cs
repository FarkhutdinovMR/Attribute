public interface ILevel
{
    uint Value { get; }
    uint MaxValue { get; }
    bool IsMaxReached => Value >= MaxValue;
    void LevelUp();
}