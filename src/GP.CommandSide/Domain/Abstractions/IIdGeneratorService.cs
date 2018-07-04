namespace GP.CommandSide.Domain.Abstractions
{
    public interface IIdGeneratorService<TId>
    {
        TId GenerateId();
    }
}
