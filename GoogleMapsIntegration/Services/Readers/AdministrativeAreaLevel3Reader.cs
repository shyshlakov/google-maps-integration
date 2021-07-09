using System;
using System.Linq;
using Abstraction.Common;
using Data;

namespace Service.Location.Readers
{
    public class AdministrativeAreaLevel3Reader : IDataReader<string, Guid?>
    {
        #region Properties : Protected

        protected BaseDbContext DbContext { get; }

        #endregion

        #region Constructor

        public AdministrativeAreaLevel3Reader(BaseDbContext dbContext)
            => DbContext = dbContext;

        #endregion

        #region Methods : Public

        public Guid? ReadData(string location)
        {
            Guid existingId = DbContext.AdministrativeAreasLevel3
               .Where(l => l.Name.ToLower() == location.ToLower())
               .Select(l => l.Id).FirstOrDefault();
            return existingId != Guid.Empty ? existingId as Guid? : null;
        }

        #endregion
    }
}
