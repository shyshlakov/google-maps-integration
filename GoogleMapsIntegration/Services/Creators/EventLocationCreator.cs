using System;
using Abstraction.Common;
using AutoMapper;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class EventLocationCreator : IDataCreator<BaseLocationCreatorModel, Guid>
    {
        #region Properties : Protected

        private readonly BaseDbContext dbContext;

        private readonly IMapper mapper;

        #endregion

        #region Constructor

        public EventLocationCreator(BaseDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        #endregion

        #region Methods : Public

        public Guid Create(BaseLocationCreatorModel model, bool saveChanges)
        {
            var eventLocation = new EventLocation();
            mapper.Map(model, eventLocation);
            dbContext.EventLocations.Add(eventLocation);

            if (saveChanges)
                dbContext.SaveChanges();

            return eventLocation.Id;
        }

        #endregion
    }
}
