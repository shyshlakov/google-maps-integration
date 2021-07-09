using System;
using System.Linq;
using Abstraction.Common;
using AutoMapper;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class ClientLocationCreator : IDataCreator<BaseLocationCreatorModel, Guid>
    {
        #region Properties : Protected

        private readonly BaseDbContext dbContext;

        private readonly IMapper mapper;

        #endregion

        #region Constructor

        public ClientLocationCreator(BaseDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        #endregion

        #region Methods : Public

        public Guid Create(BaseLocationCreatorModel model, bool saveChanges)
        {
            var clientLocation = new ClientLocation();
            mapper.Map(model, clientLocation);
            dbContext.ClientLocations.Add(clientLocation);

            if (saveChanges)
                dbContext.SaveChanges();

            return clientLocation.Id;
        }

        #endregion
    }
}
