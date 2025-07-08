using Apllication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _repo;
        public ProductController(IProductInterface repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Return a product's list
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var ListOfProduct = await _repo.ProductList();
            return Ok(ListOfProduct);
        }
        /// <summary>
        ///  Get product's information by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductInformation(string name)
        {
            var clientInfo = await _repo.ProductInformation(name);

            return Ok(clientInfo);
        }
        /// <summary>
        /// change state of products
        /// </summary>
        /// <param name="name"></param>
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await _repo.ChangeState(name);

            return Ok($"the status of product:{name} has been changed succesfully");
        }
    }
}
