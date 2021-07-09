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
    public class LocationFactory : ILocationFactory
    {
        private readonly IEnumerable<IDataCreator<BaseLocationCreatorModel, Guid>> locationCreators;

        private readonly IEnumerable<IDataDeleter<Guid>> locationDeleters;

        private readonly IEnumerable<IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>>> locationModelGenerator;

        public LocationFactory(
            IEnumerable<IDataCreator<BaseLocationCreatorModel, Guid>> locationCreators,
            IEnumerable<IDataDeleter<Guid>> locationDeleters,
            IEnumerable<IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>>> locationModelGenerator)
        {
            this.locationCreators = locationCreators;
            this.locationDeleters = locationDeleters;
            this.locationModelGenerator = locationModelGenerator;
        }

        public virtual IDataCreator<BaseLocationCreatorModel, Guid> GetLocationCreator(LocationHandlerEnum value)
            => locationCreators.First(x => x.GetType().Equals(GetLocationCreatorType()[value]));

        public virtual IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>> GetLocationModelGenerator(LocationHandlerEnum value)
            => locationModelGenerator.First(x => x.GetType().Equals(GetLocationModelGeneratorType()[value]));

        private Dictionary<LocationHandlerEnum, Type> GetLocationCreatorType()
            => new Dictionary<LocationHandlerEnum, Type>()
            {
                {LocationHandlerEnum.Client, typeof(ClientLocationCreator)},
                {LocationHandlerEnum.Event, typeof(EventLocationCreator)}
            };

        private Dictionary<LocationHandlerEnum, Type> GetLocationModelGeneratorType()
            => new Dictionary<LocationHandlerEnum, Type>()
            {
                {LocationHandlerEnum.Client, typeof(ClientLocationModelGenerator)},
                {LocationHandlerEnum.Event, typeof(EventLocationModelGenerator)},
                {LocationHandlerEnum.EventNotification, typeof(EventNotificationLocationModelGenerator)},
            };
    }
}
