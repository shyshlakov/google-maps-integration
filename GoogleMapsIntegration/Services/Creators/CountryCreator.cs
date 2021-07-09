using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class CountryCreator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public CountryCreator(BaseDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var country = new Country()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.Countries.Add(country);

            if (saveChanges)
                DbContext.SaveChanges();

            return country.Id;
        }

        #endregion
    }
}
