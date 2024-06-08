using Entities.Entites;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace inventory_control_ZDZCode.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("v1/GetAllProducts")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                var result = await _productService.GetAllProducts();
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/GetProductById/{idProduct}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<Product>> GetProductById(int idProduct)
        {
            try
            {
                var result = await _productService.GetProductById(idProduct);
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/CreateProduct")]
        [SwaggerResponse(StatusCodes.Status201Created, "Success", typeof(ProductDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<Product>> CreateProduct(ProductDTO product)
        {
            if (!ModelState.IsValid) return BadRequest("Campos Invalidos!!!");

            try
            {
                var result = await _productService.CreateProduct(product);
                if (result == null) return this.StatusCode(StatusCodes.Status400BadRequest);

                return this.StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("v1/UpdateProduct/{idProduct}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(ProductDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<bool>> UpdateProduct(int idProduct, ProductDTO product)
        {
            if (idProduct != product.IdProduct) return this.StatusCode(StatusCodes.Status400BadRequest, "Id do Produto Invalido!!!");

            if (!ModelState.IsValid) return this.StatusCode(StatusCodes.Status400BadRequest, "Campos Invalidos!!!");

            try
            {
                var result = await _productService.UpdateProduct(product);
                if (!result) return this.StatusCode(StatusCodes.Status400BadRequest);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("v1/DeleteProduct/{idProduct}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<bool>> DeleteProduct(int idProduct)
        {
            try
            {
                var result = await _productService.DeleteProduct(idProduct);
                if (!result) return this.StatusCode(StatusCodes.Status400BadRequest);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
