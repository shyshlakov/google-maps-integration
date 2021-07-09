using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class LocalityCreator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public LocalityCreator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var locality = new Locality()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.Localities.Add(locality);

            if (saveChanges)
                DbContext.SaveChanges();

            return locality.Id;
        }

        #endregion
    }
}
