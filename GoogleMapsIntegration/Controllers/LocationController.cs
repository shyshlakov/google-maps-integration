using Abstraction.Location;
using Data;
using Microsoft.AspNetCore.Mvc;
using Model.Location;
using Service.Location.Handlers;

namespace GoogleMapsIntegration.Controllers.Location
{
    [Route("api/location")]
    public class LocationController : Controller
    {
        #region Fields : Private

        private readonly BaseDbContext dbContext;

        private readonly ILocationHandlerFactory locationHandlerFactory;

        #endregion

        #region Constructor

        public LocationController(BaseDbContext dbContext, ILocationHandlerFactory locationHandlerFactory)
        {
            this.dbContext = dbContext;
            this.locationHandlerFactory = locationHandlerFactory;
        }

        #endregion

        #region Methods : Public

        [HttpPut]
        [Route("client")]
        public IActionResult AddClientLocation([FromBody]LocationModel location)
        {
            locationHandlerFactory.GetLocationHandler(LocationHandlerEnum.Client)?.HandleLocationParts(location);
            return Created(string.Empty, null);
        }

        [HttpPut]
        [Route("event")]
        public IActionResult AddEventLocation([FromBody]LocationModel location)
        {
            locationHandlerFactory.GetLocationHandler(LocationHandlerEnum.Event)?.HandleLocationParts(location);
            return Created(string.Empty, null);
        }

        #endregion
    }
}