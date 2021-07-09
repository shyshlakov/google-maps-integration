using System;
using System.Linq;
using Abstraction.Common;
using Data;
using Data.Entities.Location;

namespace Service.Location.Readers
{
    public class EventLocationReader : IDataReader<Guid?, EventLocation>
    {
        #region Fields : Private

        private readonly BaseDbContext dbContext;

        #endregion

        #region Constructor

        public EventLocationReader(BaseDbContext dbContext)
            => this.dbContext = dbContext;

        #endregion

        #region Methods : Public

        public EventLocation ReadData(Guid? eventId)
            => dbContext.EventLocations.FirstOrDefault(x => x.EventId == eventId);

        #endregion
    }
}
