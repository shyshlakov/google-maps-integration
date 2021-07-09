using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class AdministrativeAreaLevel1Creator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public AdministrativeAreaLevel1Creator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var administrativeAreaLevel1 = new AdministrativeAreaLevel1()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.AdministrativeAreasLevel1.Add(administrativeAreaLevel1);

            if (saveChanges)
                DbContext.SaveChanges();

            return administrativeAreaLevel1.Id;
        }

        #endregion
    }
}
