using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EcommerceEntities;
using Services;
using Specification;

namespace AuthWebAPI.Controllers
{
    public class ProductsController : ApiController //WEB API
    {
        //CRUD  Operation
        // GET api/values
        public IEnumerable<Product> Get() //return type is collection
        {
            IProductService svc = new ProductService();
            List<Product> products = svc.GetAll();

            return products;
        }

        // GET api/values/5
        public Product Get(int id)
        {
            IProductService svc = new ProductService();
            Product products = svc.Get(id);

            return products;
        }

        // POST api/values
        public void Post([FromBody] Product p)
        {
            IProductService svc = new ProductService(); 
            svc.Insert(p);  
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Product p)
        {
            IProductService svc = new ProductService();
            svc.Update(p);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            IProductService svc = new ProductService(); 
            svc.Delete(id); 
        }
    }
}
