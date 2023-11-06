using AmelaFood.SessionExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyProject.AppService.IService;
using MyProject.Models.Models;

namespace MyProject.Controllers;

public class MenuController : Controller
{
    private readonly IProductService _productService;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public MenuController(IProductService productService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _productService = productService;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    // GET
   public async Task<IActionResult> Index(int page = 1)
        {
            var pageSize = 3;
            var response = await _productService.GetAllProduct(page, pageSize);
            ViewBag.ListProduct = response;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
             // var product = await _productService.GetProductById(productId);
             var product = new Product();
            var quantity = 1;

            List<OrderProduct> orderProducts =
                HttpContext.Session.Get<List<OrderProduct>>(Constant.Constants.OrderProducts) ?? new List<OrderProduct>();

            if (product != null)
            {
                List<Product> addedProducts =
                    HttpContext.Session.Get<List<Product>>(Constant.Constants.Products) ?? new List<Product>();

                addedProducts.Add(product);
                var existingProduct = orderProducts.FirstOrDefault(op => op.ProductId == productId);
                if (existingProduct != null)
                {
                    existingProduct.Quantity ++;
                }
                else
                {
                    var orderProduct = new OrderProduct
                    {
                        Quantity = quantity,
                        ProductId = product.Id,
                        Product = product,
                    };

                    orderProducts.Add(orderProduct);
                }


                HttpContext.Session.Set(Constant.Constants.OrderProducts, orderProducts);
                HttpContext.Session.Set(Constant.Constants.Products, addedProducts);
            }

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<List<OrderProduct>>CartInfo()
        {
            var cartItems = HttpContext.Session.Get<List<OrderProduct>>(Constant.Constants.OrderProducts);
            if (cartItems.Count != 0)
            {
                ViewData["OrderProduct"] = cartItems;
                return cartItems;
            }

            return cartItems;
        }

        [HttpPost]
        public async Task<bool> AddBill(string customerName, decimal total)
        {
            var name = User.Identity.Name;
            
            return true;
        }
}