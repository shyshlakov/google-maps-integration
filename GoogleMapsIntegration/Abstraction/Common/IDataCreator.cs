namespace Abstraction.Common
{
    public interface IDataCreator<TIn, TOut>
    {
        TOut Create(TIn model, bool saveChanges = true);
    }
}
