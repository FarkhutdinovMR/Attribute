public interface IHealth
{
    uint Value { get; }
    uint MaxValue { get; }
    bool IsAlive => Value > 0;
    void TakeDamage(uint value);
}