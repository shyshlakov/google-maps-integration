using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Location
{
    public class ClientLocation : BaseLocation
    {
        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
