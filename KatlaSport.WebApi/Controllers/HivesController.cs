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
    [RoutePrefix("api/hives")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    [SwaggerResponseRemoveDefaults]
    public class HivesController : ApiController
    {
        private readonly IHiveService _hiveService;
        private readonly IHiveSectionService _hiveSectionService;

        public HivesController(IHiveService hiveService, IHiveSectionService hiveSectionService)
        {
            _hiveService = hiveService ?? throw new ArgumentNullException(nameof(hiveService));
            _hiveSectionService = hiveSectionService ?? throw new ArgumentNullException(nameof(hiveSectionService));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of hives.", Type = typeof(HiveListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHives()
        {
            var hives = await _hiveService.GetHivesAsync();
            return Ok(hives);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{hiveId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a hive.", Type = typeof(Hive))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHive(int hiveId)
        {
            var hive = await _hiveService.GetHiveAsync(hiveId);
            return Ok(hive);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{hiveId:int:min(1)}/sections")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of hive sections for specified hive.", Type = typeof(HiveSectionListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSections(int hiveId)
        {
            var hive = await _hiveSectionService.GetHiveSectionsAsync(hiveId);
            return Ok(hive);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new hive")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Bad request initiated")]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddHive([System.Web.Http.FromBody] UpdateHiveRequest createHiveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hive = await _hiveService.CreateHiveAsync(createHiveRequest);
            var location = $"/api/hives/{hive.Id}";
            return Created<Hive>(location, hive);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed hive")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Bad request initiated")]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateHive([FromUri] int id, [System.Web.Http.FromBody] UpdateHiveRequest updateHiveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hiveService.UpdateHiveAsync(id, updateHiveRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed hive.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteHive([FromUri] int id)
        {
            await _hiveService.DeleteHiveAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("{hiveId:int:min(1)}/status/{deletedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed hive.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetStatus([FromUri] int hiveId, [FromUri] bool deletedStatus)
        {
            await _hiveService.SetStatusAsync(hiveId, deletedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
