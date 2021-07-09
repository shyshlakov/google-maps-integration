using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class AdministrativeAreaLevel3Creator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public AdministrativeAreaLevel3Creator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var administrativeAreaLevel3 = new AdministrativeAreaLevel3()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.AdministrativeAreasLevel3.Add(administrativeAreaLevel3);

            if (saveChanges)
                DbContext.SaveChanges();

            return administrativeAreaLevel3.Id;
        }

        #endregion
    }
}
