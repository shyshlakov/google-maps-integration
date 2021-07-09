using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction.Common;
using Abstraction.Location;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Handlers
{
    public class EventLocationHandler : BaseLocationHandler
    {
        #region Fields : Private

        private readonly ILocationFactory locationFactory;

        #endregion

        #region Properties : Protected

        protected IDataReader<Guid?, EventLocation> DataReader { get; set; }

        protected IDataUpdater<(BaseLocationCreatorModel, EventLocation), Guid?> DataUpdater { get; set; }

        #endregion

        #region Constructor

        public EventLocationHandler(
            BaseDbContext dbContext,
            IDataReader<Guid?, EventLocation> dataReader,
            IDataUpdater<(BaseLocationCreatorModel, EventLocation), Guid?> dataUpdater,
            BaseLocationPartHandler locationPartHandler,
            ILocationFactory locationFactory)
            : base(dbContext,
                  locationFactory.GetLocationModelGenerator(LocationHandlerEnum.Event),
                  locationPartHandler)
        {
            this.locationFactory = locationFactory;
            DataReader = dataReader;
            DataUpdater = dataUpdater;
        }

        protected override BaseLocationCreatorModel HandleParts(LocationModel model, IDictionary<string, string> locationParts)
        {
            var resultModel = new BaseLocationCreatorModel()
            {
                LocationParts = new Dictionary<string, Guid?>()
            };
            resultModel.LocationParts.Add(Handle(
                "route",
                locationParts["route"],
                model.PlaceID));
            locationParts.Remove("route");
            foreach (KeyValuePair<string, string> locationPart in locationParts.Where(x => !string.IsNullOrEmpty(x.Value)))
            {
                resultModel.LocationParts.Add(Handle(locationPart.Key, locationPart.Value));
            }
            return resultModel;
        }


        protected override Guid? CreateLocation(LocationModel model, BaseLocationCreatorModel creatorModel)
        {
            EventLocation eventLocation = DataReader.ReadData(model.EntityID);
            return eventLocation != null
                ? DataUpdater.Update((creatorModel, eventLocation))
                : locationFactory.GetLocationCreator(LocationHandlerEnum.Event)?.Create(creatorModel);
        }

        #endregion
    }
}
