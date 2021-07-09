using System;
using System.Collections.Generic;

namespace Model.Location
{
    public class LocationCollectionModel
    {
        public Guid EntityId { get; set; }

        public IEnumerable<LocationModel> Locations { get; set; }
    }
}
