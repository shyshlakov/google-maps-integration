namespace Abstraction.Common
{
    public interface IModelGenerator<TIn, TOut>
    {
        public TOut Generate(TIn model);
    }
}
