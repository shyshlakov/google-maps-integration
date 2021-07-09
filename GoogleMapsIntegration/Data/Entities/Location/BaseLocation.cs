using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Location
{
    public class BaseLocation : BaseEntity
    {
        [ForeignKey(nameof(Locality))]
        public Guid? LocalityId { get; set; }
        public virtual Locality Locality { get; set; }

        [ForeignKey(nameof(AdministrativeAreaLevel1))]
        public Guid? AdministrativeAreaLevel1Id { get; set; }
        public virtual AdministrativeAreaLevel1 AdministrativeAreaLevel1 { get; set; }

        [ForeignKey(nameof(AdministrativeAreaLevel2))]
        public Guid? AdministrativeAreaLevel2Id { get; set; }
        public virtual AdministrativeAreaLevel2 AdministrativeAreaLevel2 { get; set; }

        [ForeignKey(nameof(AdministrativeAreaLevel3))]
        public Guid? AdministrativeAreaLevel3Id { get; set; }
        public virtual AdministrativeAreaLevel3 AdministrativeAreaLevel3 { get; set; }

        [ForeignKey(nameof(AdministrativeAreaLevel4))]
        public Guid? AdministrativeAreaLevel4Id { get; set; }
        public virtual AdministrativeAreaLevel4 AdministrativeAreaLevel4 { get; set; }

        [ForeignKey(nameof(AdministrativeAreaLevel5))]
        public Guid? AdministrativeAreaLevel5Id { get; set; }
        public virtual AdministrativeAreaLevel5 AdministrativeAreaLevel5 { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
