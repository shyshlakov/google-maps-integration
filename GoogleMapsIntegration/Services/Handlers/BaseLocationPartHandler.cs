using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction.Common;
using Abstraction.Location;
using Model.Location;
using Service.Location.Creators;
using Service.Location.Readers;

namespace Service.Location.Handlers
{
    public class BaseLocationPartHandler
    {
        #region Properties : Protected

        protected IEnumerable<IDataReader<string, Guid?>> DataReaders { get; }

        protected IEnumerable<IDataCreator<LocationPartCreatorModel, Guid>> DataCreators { get; }

        protected IGeolocationService GoogleAPIService { get; }
        #endregion

        #region Constructor

        public BaseLocationPartHandler(
            IEnumerable<IDataReader<string, Guid?>> dataReaders,
            IEnumerable<IDataCreator<LocationPartCreatorModel, Guid>> dataCreators,
            IGeolocationService googleAPIService)
        {
            DataReaders = dataReaders;
            DataCreators = dataCreators;
            GoogleAPIService = googleAPIService;
        }

        #endregion

        #region Methods : Public

        public Guid? HandleLocationPartByLocationName(string locationKey, string locationName, string placeId = null)
        {
            Guid? result = null;
            switch (locationKey)
            {
                case "locality":
                    {
                        result = HandleLocationPart(
                            DataReaders.Where(x => x.GetType().Equals(typeof(LocalityReader))).FirstOrDefault(),
                            DataCreators.Where(x => x.GetType().Equals(typeof(LocalityCreator))).FirstOrDefault(),
                            locationName, placeId);
                        break;
                    }
                case "administrative_area_level_1":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel1Reader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel1Creator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
                case "administrative_area_level_2":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel2Reader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel2Creator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
                case "administrative_area_level_3":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel3Reader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel3Creator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
                case "administrative_area_level_4":
                    {
                        result = HandleLocationPart(
                            DataReaders.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel4Reader))).FirstOrDefault(),
                            DataCreators.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel4Creator))).FirstOrDefault(),
                            locationName, placeId);
                        break;
                    }
                case "administrative_area_level_5":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel5Reader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(AdministrativeAreaLevel5Creator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
                case "country":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(CountryReader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(CountryCreator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
                case "sublocality":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(SublocalityReader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(SublocalityCreator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
                case "route":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(RouteReader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(RouteCreator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
                case "postal_code":
                    {
                        result = HandleLocationPart(
                           DataReaders.Where(x => x.GetType().Equals(typeof(PostalCodeReader))).FirstOrDefault(),
                           DataCreators.Where(x => x.GetType().Equals(typeof(PostalCodeCreator))).FirstOrDefault(),
                           locationName, placeId);
                        break;
                    }
            }
            return result;
        }

        public Guid? HandleLocationPart(
            IDataReader<string, Guid?> reader,
            IDataCreator<LocationPartCreatorModel, Guid> creator,
            string locationName, string placeId = null)
            => string.IsNullOrEmpty(placeId)
                ? reader?.ReadData(locationName)
                    ?? creator?.Create(
                        new LocationPartCreatorModel()
                        {
                            LocationName = locationName,
                            PlaceId = GoogleAPIService.GetPlaceIDByName(locationName)
                        }, false)
                : reader?.ReadData(placeId)
                    ?? creator?.Create(
                        new LocationPartCreatorModel()
                        {
                            LocationName = locationName,
                            PlaceId = placeId
                        }, false);

        #endregion
    }

}
