using System;
using System.Collections.Generic;
using Abstraction.Common;
using Model.Location;

namespace Abstraction.Location
{
    public interface ILocationFactory
    {
        IDataCreator<BaseLocationCreatorModel, Guid> GetLocationCreator(LocationHandlerEnum value);

        IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>> GetLocationModelGenerator(LocationHandlerEnum value);
    }
}
