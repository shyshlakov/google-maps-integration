using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class AdministrativeAreaLevel4Creator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public AdministrativeAreaLevel4Creator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var administrativeAreaLevel4 = new AdministrativeAreaLevel4()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.AdministrativeAreasLevel4.Add(administrativeAreaLevel4);

            if (saveChanges)
                DbContext.SaveChanges();

            return administrativeAreaLevel4.Id;
        }

        #endregion
    }
}
