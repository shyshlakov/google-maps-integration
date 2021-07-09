namespace Abstraction.Common
{
    public interface IDataUpdater<TIn, TOut>
    {
        TOut Update(TIn model);
    }
}
