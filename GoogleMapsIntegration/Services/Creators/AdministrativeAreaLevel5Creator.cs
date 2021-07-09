using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class AdministrativeAreaLevel5Creator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public AdministrativeAreaLevel5Creator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var administrativeAreaLevel5 = new AdministrativeAreaLevel5()
            {
                Name = model.LocationName,
                PlaceID = model.PlaceId
            };
            DbContext.AdministrativeAreasLevel5.Add(administrativeAreaLevel5);

            if (saveChanges)
                DbContext.SaveChanges();

            return administrativeAreaLevel5.Id;
        }

        #endregion
    }
}
