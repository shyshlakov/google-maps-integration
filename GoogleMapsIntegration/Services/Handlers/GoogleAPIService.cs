using System;
using System.Linq;
using Abstraction.Location;
using GoogleApi.Entities.Places.Search.Find.Request;
using Microsoft.Extensions.Options;
using Model.Location;

namespace Service.Location.Handlers
{
    public class GoogleAPIService : IGeolocationService
    {
        #region Properties : Protected

        protected GoogleAPIConfig GoogleAPIConfig { get; }

        #endregion

        #region Constructor

        public GoogleAPIService(IOptions<GoogleAPIConfig> options)
        {
            GoogleAPIConfig = options.Value;
        }

        #endregion

        #region Methods : Public

        public string GetPlaceIDByName(string name)
        {
            try
            {
                var request = new PlacesFindSearchRequest();
                request.Input = name;
                request.Key = GoogleAPIConfig.Key;
                var response = GoogleApi.GooglePlaces.FindSearch.Query(request);
                return response.Candidates.FirstOrDefault()?.PlaceId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion
    }
}