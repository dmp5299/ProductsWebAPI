using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsWebAPI.Models;

namespace ProductsWebAPI.Services
{
    public interface IProductsService
    {
        List<Product> getProducts(int id);
        List<ProductType> getProductTypes();
    }
}
