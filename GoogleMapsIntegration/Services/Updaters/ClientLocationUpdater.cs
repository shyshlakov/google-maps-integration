using System;
using Abstraction.Common;
using AutoMapper;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Updaters
{
    public class ClientLocationUpdater : IDataUpdater<(BaseLocationCreatorModel, ClientLocation), Guid?>
    {
        #region Properties : Protected

        private readonly BaseDbContext dbContext;

        private readonly IMapper mapper;

        #endregion

        #region Constructor

        public ClientLocationUpdater(BaseDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        #endregion

        #region Methods : Public

        public Guid? Update((BaseLocationCreatorModel, ClientLocation) model)
        {
            mapper.Map(model.Item1, model.Item2);
            dbContext.ClientLocations.Update(model.Item2);
            dbContext.SaveChanges();
            return model.Item2.Id;
        }

        #endregion
    }
}
