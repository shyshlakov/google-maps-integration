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
    public class ClientLocationHandler : BaseLocationHandler
    {
        #region Fields : Private

        private readonly ILocationFactory locationFactory;

        #endregion

        #region Properties : Protected

        protected IDataReader<Guid?, ClientLocation> DataReader { get; set; }

        protected IDataUpdater<(BaseLocationCreatorModel, ClientLocation), Guid?> DataUpdater { get; set; }

        #endregion

        #region Constructor

        public ClientLocationHandler(
            BaseDbContext dbContext,           
            IDataReader<Guid?, ClientLocation> dataReader,
            IDataUpdater<(BaseLocationCreatorModel, ClientLocation), Guid?> dataUpdater,
            BaseLocationPartHandler locationPartHandler,
            ILocationFactory locationFactory)
            : base(dbContext, locationFactory.GetLocationModelGenerator(LocationHandlerEnum.Client),
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
                "locality",
                locationParts["locality"],
                model.PlaceID));
            locationParts.Remove("locality");
            foreach (KeyValuePair<string, string> locationPart in locationParts.Where(x => !string.IsNullOrEmpty(x.Value)))
            {
                resultModel.LocationParts.Add(Handle(locationPart.Key, locationPart.Value));
            }
            return resultModel;
        }


        protected override Guid? CreateLocation(LocationModel model, BaseLocationCreatorModel creatorModel)
        {
            ClientLocation clientLocation = DataReader.ReadData(model.EntityID);
            return clientLocation != null
                ? DataUpdater.Update((creatorModel, clientLocation))
                : locationFactory.GetLocationCreator(LocationHandlerEnum.Client)?.Create(creatorModel);
        }

        #endregion
    }
}
