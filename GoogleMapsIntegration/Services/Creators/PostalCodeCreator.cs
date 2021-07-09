using System;
using Abstraction.Common;
using Data;
using Data.Entities.Location;
using Model.Location;

namespace Service.Location.Creators
{
    public class PostalCodeCreator : IDataCreator<LocationPartCreatorModel, Guid>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public PostalCodeCreator(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid Create(LocationPartCreatorModel model, bool saveChanges)
        {
            var postalCode = new PostalCode()
            {
                Name = model.LocationName
            };
            DbContext.PostalCodes.Add(postalCode);

            if (saveChanges)
                DbContext.SaveChanges();

            return postalCode.Id;
        }

        #endregion
    }
}
