using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.ProductManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/categories")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class ProductCategoriesController : ApiController
    {
        private readonly IProductCategoryService _categoryService;
        private readonly IProductCatalogueService _productCatalogueService;

        public ProductCategoriesController(IProductCategoryService categoryService, IProductCatalogueService productCatalogueService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _productCatalogueService = productCatalogueService ?? throw new ArgumentNullException(nameof(productCatalogueService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of product categories.", Type = typeof(ProductCategoryListItem[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetProductCategories([FromUri] int start = 0, [FromUri] int amount = 100)
        {
            if (start < 0)
            {
                return BadRequest("start");
            }
            if (amount < 0)
            {
                return BadRequest("end");
            }

            var categories = await _categoryService.GetCategoriesAsync(start, amount);
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a product category.", Type = typeof(ProductCategory))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetProductCategory([FromUri] int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            return Ok(category);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new product category.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddProductCategory([FromBody] UpdateProductCategoryRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.CreateCategoryAsync(createRequest);
            var location = string.Format("/api/categories/{0}", category.Id);
            return Created<ProductCategory>(location, category);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed product category.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateProductCategory([FromUri] int id, [FromBody] UpdateProductCategoryRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.UpdateCategoryAsync(id, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed product category.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteProductCategory([FromUri] int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPut]
        [Route("{id:int:min(1)}/status/{deletedStatus:bool}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed product category.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetStatus([FromUri] int id, [FromUri] bool deletedStatus)
        {
            await _categoryService.SetStatusAsync(id, deletedStatus);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpGet]
        [Route("{id:int:min(1)}/products")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of products for requested product category.", Type = typeof(ProductCategoryProductListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetProducts([FromUri] int id)
        {
            var products = await _productCatalogueService.GetCategoryProductsAsync(id);
            return Ok(products);
        }
    }
}
