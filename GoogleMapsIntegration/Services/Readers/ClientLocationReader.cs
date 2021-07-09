using System;
using System.Linq;
using Abstraction.Common;
using Data;
using Data.Entities.Location;

namespace Service.Location.Readers
{
    public class ClientLocationReader : IDataReader<Guid?, ClientLocation>
    {
        #region Fields : Private

        private readonly BaseDbContext dbContext;

        #endregion

        #region Constructor

        public ClientLocationReader(BaseDbContext dbContext)
            => this.dbContext = dbContext;

        #endregion

        #region Methods : Public

        public ClientLocation ReadData(Guid? clientId)
            => dbContext.ClientLocations.FirstOrDefault(x => x.ClientId == clientId);

        #endregion
    }
}
