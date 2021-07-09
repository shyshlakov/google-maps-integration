using System;
using Model.Location;

namespace Abstraction.Location
{
    public interface ILocationHandlerFactory
    {
        ILocationHandler<LocationModel, Guid?> GetLocationHandler(LocationHandlerEnum value);
    }
}
