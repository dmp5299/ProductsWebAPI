using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProductsWebAPI.Models;

namespace ProductsWebAPI.Services
{
    public class ProductsService : IProductsService
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["productsAPIConnString"].ConnectionString);

        public List<ProductType> getProductTypes()
        {
            SqlCommand command = new SqlCommand("select * from ProductType", this.connection);
            List<ProductType> productTypes = new List<ProductType>();
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductType product = new ProductType()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        productTypes.Add(product);
                    }
                }
                return productTypes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<Product> getProducts(int id)
        {
            SqlCommand command = new SqlCommand($"select * from Products where TypeId={id}", this.connection);
            List<Product> productTypes = new List<Product>();
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product()
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        };
                        productTypes.Add(product);
                    }
                }
                return productTypes;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}