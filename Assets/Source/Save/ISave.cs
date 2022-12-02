public interface ISave<TAbstract>
{
    void Save(TAbstract data);
    TConcrete Load<TConcrete>();
}