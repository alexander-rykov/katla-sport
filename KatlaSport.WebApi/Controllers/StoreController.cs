using KatlaSport.Services.ProductManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/store")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    [SwaggerResponseRemoveDefaults]
    public class StoreController : ApiController
    {
        private readonly IStoreProductService _itemService;
        private readonly IProductSectionCategoryService _categoryService;

        public StoreController(IStoreProductService itemService, IProductSectionCategoryService categoryService)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of stored items.", Type = typeof(ProductStoreItem[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetItems()
        {
            var items = await _itemService.GetItemsAsync();
            return Ok(items);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{sectionId:int:min(1)}/categories")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of section categories.", Type = typeof(ProductCategoryListItem[]))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSectionCategories([FromUri] int sectionId)
        {

            var categories = await _categoryService.GetSectionCategoriesAsync(sectionId);
            return Ok(categories);
        }

        //    [System.Web.Http.HttpGet]
        //    [System.Web.Http.Route("{id:int:min(1)}")]
        //    [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a product.", Type = typeof(Product))]
        //    [SwaggerResponse(HttpStatusCode.NotFound)]
        //    [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //    public async Task<IHttpActionResult> GetProduct([FromUri] int id)
        //    {
        //        var product = await _itemService.GetProductAsync(id);
        //        return Ok(product);
        //    }

        //    [System.Web.Http.HttpPost]
        //    [System.Web.Http.Route("")]
        //    [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new product.")]
        //    [SwaggerResponse(HttpStatusCode.BadRequest)]
        //    [SwaggerResponse(HttpStatusCode.Conflict)]
        //    [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //    public async Task<IHttpActionResult> AddProduct([System.Web.Http.FromBody] UpdateProductRequest createRequest)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var product = await _itemService.CreateProductAsync(createRequest);
        //        var location = string.Format("/api/products/{0}", product.Id);
        //        return Created<Product>(location, product);
        //    }

        //    [System.Web.Http.HttpPut]
        //    [System.Web.Http.Route("{id:int:min(1)}")]
        //    [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed product.")]
        //    [SwaggerResponse(HttpStatusCode.BadRequest)]
        //    [SwaggerResponse(HttpStatusCode.Conflict)]
        //    [SwaggerResponse(HttpStatusCode.NotFound)]
        //    [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //    public async Task<IHttpActionResult> UpdateProduct([FromUri] int id, [System.Web.Http.FromBody] UpdateProductRequest updateRequest)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        await _itemService.UpdateProductAsync(id, updateRequest);
        //        return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        //    }

        //    [System.Web.Http.HttpDelete]
        //    [System.Web.Http.Route("{id:int:min(1)}")]
        //    [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed product.")]
        //    [SwaggerResponse(HttpStatusCode.BadRequest)]
        //    [SwaggerResponse(HttpStatusCode.Conflict)]
        //    [SwaggerResponse(HttpStatusCode.NotFound)]
        //    [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //    public async Task<IHttpActionResult> DeleteProduct([FromUri] int id)
        //    {
        //        await _itemService.DeleteProductAsync(id);
        //        return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        //    }

        //    [System.Web.Http.HttpPut]
        //    [System.Web.Http.Route("{id:int:min(1)}/status/{deletedStatus:bool}")]
        //    [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed product category.")]
        //    [SwaggerResponse(HttpStatusCode.NotFound)]
        //    [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //    public async Task<IHttpActionResult> SetStatus([FromUri] int id, [FromUri] bool deletedStatus)
        //    {
        //        await _itemService.SetStatusAsync(id, deletedStatus);
        //        return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        //    }
    }
}
