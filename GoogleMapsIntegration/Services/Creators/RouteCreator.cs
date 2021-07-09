using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class RouteCreator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public RouteCreator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var route = new Route()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.Routes.Add(route);

            if (saveChanges)
                DbContext.SaveChanges();

            return route.Id;
        }

        #endregion
    }
}
