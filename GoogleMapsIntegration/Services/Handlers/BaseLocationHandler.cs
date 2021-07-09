using System;
using System.Collections.Generic;
using Abstraction.Common;
using Abstraction.Location;
using Data;
using Model.Location;

namespace Service.Location.Handlers
{
    public abstract class BaseLocationHandler : ILocationHandler<LocationModel, Guid?>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        protected IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>> ModelGenerator { get; }

        protected BaseLocationPartHandler LocationPartHandler { get; }

        #endregion

        #region Constructor

        public BaseLocationHandler(
            BaseDbContext dbContext,
            IModelGenerator<IDictionary<string, string[]>, IDictionary<string, string>> modelGenerator,
            BaseLocationPartHandler locationPartHandler)
        {
            DbContext = dbContext;
            ModelGenerator = modelGenerator;
            LocationPartHandler = locationPartHandler;
        }

        #endregion

        #region Methods : Public

        public virtual Guid? HandleLocationParts(LocationModel model)
        {
            if (model.EntityID != null)
            {
                IDictionary<string, string> locationParts = ModelGenerator?.Generate(model.LocationParts);
                BaseLocationCreatorModel baseLocationCreatorModel = HandleParts(model, locationParts);
                baseLocationCreatorModel.EntityId = model.EntityID;
                return CreateLocation(model, baseLocationCreatorModel);
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Methods : Protected

        protected virtual KeyValuePair<string, Guid?> Handle(string locationKey, string locationName, string placeId = null)
            => new KeyValuePair<string, Guid?>(locationKey, LocationPartHandler.HandleLocationPartByLocationName(locationKey, locationName, placeId));

        protected abstract BaseLocationCreatorModel HandleParts(LocationModel model, IDictionary<string, string> locationParts);

        protected abstract Guid? CreateLocation(LocationModel model, BaseLocationCreatorModel creatorModel);

        #endregion
    }
}
