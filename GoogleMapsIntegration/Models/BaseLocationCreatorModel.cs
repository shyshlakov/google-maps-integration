using System;
using System.Collections.Generic;

namespace Model.Location
{
    public class BaseLocationCreatorModel
    {
        public Guid? EntityId { get; set; }

        public IDictionary<string, Guid?> LocationParts { get; set; }
    }
}
