using System;
using System.Linq;
using Abstraction.Common;
using Data;

namespace Service.Location.Readers
{
    public class LocalityReader : IDataReader<string, Guid?>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public LocalityReader(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid? ReadData(string location)
        {
            Guid existingId = DbContext.Localities
                .Where(l => l.PlaceID == location || l.Name.ToLower() == location.ToLower())
                .Select(l => l.Id).FirstOrDefault();
            return existingId != Guid.Empty ? existingId as Guid? : null;
        }

        #endregion
    }
}
