using System;
using System.Threading.Tasks;

namespace Abstraction.Common
{
    public interface IDataDeleter<TIn>
    {
        Task Delete(TIn model, bool saveChanges = true);
    }
}
