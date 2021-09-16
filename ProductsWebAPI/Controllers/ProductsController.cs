using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProductsWebAPI.Models;
using ProductsWebAPI.Services;

namespace ProductsWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class ProductsController : ApiController
    {
        IProductsService _productsService;

        public ProductsController(IProductsService _productsService)
        {
            this._productsService = _productsService;
        }

        [HttpGet]
        public HttpResponseMessage ProductTypes()
        {
            try
            {
                List<ProductType> productTypes = _productsService.getProductTypes();
                return Request.CreateResponse(HttpStatusCode.OK,productTypes);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
           
        }

        [HttpPost]
        public HttpResponseMessage Products([FromBody]int id)
        {
            try
            {
                List<Product> productTypes = _productsService.getProducts(id);
                return Request.CreateResponse(HttpStatusCode.OK,productTypes);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
