using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.HiveManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sections")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    [SwaggerResponseRemoveDefaults]
    public class HiveSectionsController : ApiController
    {
        private readonly IHiveSectionService _hiveSectionService;

        public HiveSectionsController(IHiveSectionService hiveSectionService)
        {
            _hiveSectionService = hiveSectionService ?? throw new ArgumentNullException(nameof(hiveSectionService));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of hive sections.", Type = typeof(HiveSectionListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSections()
        {
            var hives = await _hiveSectionService.GetHiveSectionsAsync();
            return Ok(hives);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{hiveSectionId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive section.", Type = typeof(HiveSection))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSection(int hiveSectionId)
        {
            var hive = await _hiveSectionService.GetHiveSectionAsync(hiveSectionId);
            return Ok(hive);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new hive section.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddHiveSection(
            [System.Web.Http.FromBody] UpdateHiveSectionRequest createSectionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var section = await _hiveSectionService.CreateHiveSectionAsync(createSectionRequest);
            var location = $"/api/categories/{section.Id}";
            return Created<HiveSection>(location, section);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed hive section.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateHiveSection([FromUri] int id, [System.Web.Http.FromBody] UpdateHiveSectionRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hiveSectionService.UpdateHiveSectionAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("{hiveSectionId:int:min(1)}/status/{deletedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed hive section.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetStatus([FromUri] int hiveSectionId, [FromUri] bool deletedStatus)
        {
            await _hiveSectionService.SetStatusAsync(hiveSectionId, deletedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed hive section")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteHiveSection([FromUri] int id)
        {
            await _hiveSectionService.DeleteHiveSectionAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
