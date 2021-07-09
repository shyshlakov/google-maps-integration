using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class SublocalityCreator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public SublocalityCreator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var sublocality = new Sublocality()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.Sublocalities.Add(sublocality);

            if (saveChanges)
                DbContext.SaveChanges();

            return sublocality.Id;
        }

        #endregion
    }
}
