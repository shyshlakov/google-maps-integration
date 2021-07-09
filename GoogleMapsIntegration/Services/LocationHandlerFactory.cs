using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction.Common;
using Abstraction.Location;
using Model.Location;
using Service.Location.Creators;
using Service.Location.Handlers;

namespace Service.Location
{
    public class LocationHandlerFactory : ILocationHandlerFactory
    {
        private readonly IEnumerable<ILocationHandler<LocationModel, Guid?>> locationHandlers;

        public LocationHandlerFactory(
            IEnumerable<ILocationHandler<LocationModel, Guid?>> locationHandlers)
        {
            this.locationHandlers = locationHandlers;
        }

        public virtual ILocationHandler<LocationModel, Guid?> GetLocationHandler(LocationHandlerEnum value)
            => locationHandlers.First(x => x.GetType().Equals(GetLocationHandlerType()[value]));

        private Dictionary<LocationHandlerEnum, Type> GetLocationHandlerType()
            => new Dictionary<LocationHandlerEnum, Type>()
            {
                {LocationHandlerEnum.Client, typeof(ClientLocationHandler)},
                {LocationHandlerEnum.Event, typeof(EventLocationHandler)}
            };
    }
}
