using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }

    public class BaseLookup : BaseEntity
    {
        [JsonProperty(PropertyName = "label")]
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class BaseLocationPart : BaseLookup
    {
        public string PlaceID { get; set; }
    }
}