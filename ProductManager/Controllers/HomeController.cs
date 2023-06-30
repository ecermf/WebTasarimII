using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
using ProductManager.Models.Entity;
using ProductManager.Services.Abstract;
using System.Diagnostics;

namespace ProductManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productManager;

        public HomeController(ILogger<HomeController> logger, IProductService productManager)
        {
            _logger = logger;
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products =await _productManager.GetProductsAsync();
            return View(products);
        }
        public async Task<IActionResult> Add()
        {
            Product p = new();
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if(ModelState.IsValid)
            {
                await _productManager.AddAsync(product);
                await _productManager.SaveAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            Product p= await _productManager.GetAsync(Id);
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product updateProduct)
        {
            if (ModelState.IsValid)
            {
                await _productManager.UpdateAsync(updateProduct);
                await _productManager.SaveAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            await _productManager.DeleteAsync(Id);
            await _productManager.SaveAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}