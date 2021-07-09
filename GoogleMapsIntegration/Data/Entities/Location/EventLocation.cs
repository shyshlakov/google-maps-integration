using System;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities;

namespace Data.Entities.Location
{
    public class EventLocation : BaseLocation
    {
        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey(nameof(Route))]
        public Guid? RouteId { get; set; }
        public virtual Route Route { get; set; }

        [ForeignKey(nameof(Sublocality))]
        public Guid? SublocalityId { get; set; }
        public virtual Sublocality Sublocality { get; set; }

        [ForeignKey(nameof(PostalCode))]
        public Guid? PostalCodeId { get; set; }
        public virtual PostalCode PostalCode { get; set; }
    }
}
