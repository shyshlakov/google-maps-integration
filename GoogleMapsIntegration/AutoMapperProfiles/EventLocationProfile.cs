﻿using System;
using AutoMapper;
using Data.Entities.Location;
using Model.Location;

namespace Api.AutoMapperProfiles
{
    public class EventLocationProfile : Profile
    {
        public EventLocationProfile()
        {
            CreateMap<BaseLocationCreatorModel, EventLocation>()
                .ForMember(dest => dest.LocalityId,
                    opt => opt.MapFrom(src => GetLocationValue(src, "locality")))
                .ForMember(dest => dest.AdministrativeAreaLevel1Id,
                    opt => opt.MapFrom(src => GetLocationValue(src, "administrative_area_level_1")))
                .ForMember(dest => dest.AdministrativeAreaLevel2Id,
                    opt => opt.MapFrom(src => GetLocationValue(src, "administrative_area_level_2")))
                .ForMember(dest => dest.AdministrativeAreaLevel3Id,
                   opt => opt.MapFrom(src => GetLocationValue(src, "administrative_area_level_3")))
                .ForMember(dest => dest.AdministrativeAreaLevel4Id,
                    opt => opt.MapFrom(src => GetLocationValue(src, "administrative_area_level_4")))
               .ForMember(dest => dest.AdministrativeAreaLevel5Id,
                    opt => opt.MapFrom(src => GetLocationValue(src, "administrative_area_level_5")))
               .ForMember(dest => dest.CountryId,
                    opt => opt.MapFrom(src => GetLocationValue(src, "country")))
               .ForMember(dest => dest.SublocalityId,
                    opt => opt.MapFrom(src => GetLocationValue(src, "sublocality")))
               .ForMember(dest => dest.PostalCodeId,
                    opt => opt.MapFrom(src => GetLocationValue(src, "postal_code")))
               .ForMember(dest => dest.RouteId,
                    opt => opt.MapFrom(src => GetLocationValue(src, "route")))
               .ForMember(dest => dest.EventId,
                    opt => opt.MapFrom(src => src.EntityId ?? Guid.Empty));
        }

        private Guid? GetLocationValue(BaseLocationCreatorModel model, string pathName)
            => model.LocationParts.TryGetValue(pathName, out Guid? locality) ? locality : null;
    }
}
