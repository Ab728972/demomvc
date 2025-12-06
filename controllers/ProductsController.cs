using demomvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class ProductsController : Controller
    {
        // Action Method Model Binding
        // Model Binder
        // Route Data    => /BaseUrl/C/A/{value}
        // Query String  => /BaseUrl/C/A?id=value
        // HTML Form
        // Request Body  => XML || Json
        // Headers       => [FromHeader]

        public string Get(int id)
        {
            return $"Product With Id {id}";
        }

        public string Create(int id, string name, product product)
        {
            return $"Product With Id {id} :: Name {name}\n{product.Id} :: {product.Name}";
        }
    }
}