using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class AdministrativeAreaLevel2Creator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public AdministrativeAreaLevel2Creator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var administrativeAreaLevel2 = new AdministrativeAreaLevel2()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.AdministrativeAreasLevel2.Add(administrativeAreaLevel2);

            if (saveChanges)
                DbContext.SaveChanges();

            return administrativeAreaLevel2.Id;
        }

        #endregion
    }
}
