namespace Abstraction.Common
{
    public interface IDataReader<TIn, TOut>
    {
        TOut ReadData(TIn model);
    }
}