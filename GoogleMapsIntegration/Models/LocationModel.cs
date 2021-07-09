using System;
using System.Collections.Generic;

namespace Model.Location
{
    public class LocationModel
    {
        public Guid? EntityID { get; set; }

        public string PlaceID { get; set; }

        public IDictionary<string, string[]> LocationParts { get; set; }
    }
}
