using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.ProductManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/items")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    [SwaggerResponseRemoveDefaults]
    public class StoreItemsController : ApiController
    {
        private readonly IStoreProductService _productService;

        public StoreItemsController(IStoreProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of products.", Type = typeof(ProductStoreItem[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetItems()
        {
            var products = await _productService.GetItemsAsync();
            return Ok(products);
        }

        //    [System.Web.Http.HttpGet]
        //    [System.Web.Http.Route("{id:int:min(1)}")]
        //    [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a product.", Type = typeof(Product))]
        //    [SwaggerResponse(HttpStatusCode.NotFound)]
        //    [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //    public async Task<IHttpActionResult> GetProduct([FromUri] int id)
        //    {
        //        var product = await _productService.GetProductAsync(id);
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

        //        var product = await _productService.CreateProductAsync(createRequest);
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

        //        await _productService.UpdateProductAsync(id, updateRequest);
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
        //        await _productService.DeleteProductAsync(id);
        //        return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        //    }

        //    [System.Web.Http.HttpPut]
        //    [System.Web.Http.Route("{id:int:min(1)}/status/{deletedStatus:bool}")]
        //    [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed product category.")]
        //    [SwaggerResponse(HttpStatusCode.NotFound)]
        //    [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //    public async Task<IHttpActionResult> SetStatus([FromUri] int id, [FromUri] bool deletedStatus)
        //    {
        //        await _productService.SetStatusAsync(id, deletedStatus);
        //        return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        //    }
    }
}
