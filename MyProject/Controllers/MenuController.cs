using AmelaFood.SessionExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyProject.AppService.IService;
using MyProject.Models.Dtos;
using MyProject.Models.Models;
using MyProject.Constant;
using Constants = MyProject.Constant.Constants;


namespace MyProject.Controllers;

[Authorize]
[Authorize(Roles = "USER")]
public class MenuController : Controller
{
    private readonly IProductService _productService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserService _userService;
    private readonly IOrderProductService _orderProductService;

    public MenuController(IProductService productService,
        UserManager<IdentityUser> userManager, IUserService userService, IOrderProductService orderProductService)
    {
        _productService = productService;
        _userManager = userManager;
        _userService = userService;
        _orderProductService = orderProductService;
    }

    // GET
    public async Task<IActionResult> Index(int page = 1)
    {
        var pageSize = 8;
        var response = await _productService.GetAllProduct(page, pageSize);
        ViewBag.ListProduct = response;
        ViewBag.TotalPages = response.TotalPages;
        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalItem = response.TotalItem;
        ViewBag.ListItem = response.ProductDtos;

        return View(response.ProductDtos);
    }

    public async Task<List<ProductDto>> UpdateListProduct(int page)
    {
        var pageSize = 8;
        var response = await _productService.GetAllProduct(page, pageSize);
        return response.ProductDtos;
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId)
    {
                    
        var product = await _productService.GetProductById(productId);
        var quantity = 1;

        List<OrderProduct> orderProducts =
            HttpContext.Session.Get<List<OrderProduct>>(Constants.OrderProducts) ?? new List<OrderProduct>();

        
        if (product != null)
        {
            List<Product> addedProducts =
                HttpContext.Session.Get<List<Product>>(Constants.Products) ?? new List<Product>();

            addedProducts.Add(product);
            var existingProduct = orderProducts.FirstOrDefault(op => op.ProductId == productId);
            if (existingProduct != null)
            {
                existingProduct.Quantity++;
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
            
            HttpContext.Session.Set(Constants.OrderProducts, orderProducts);
            HttpContext.Session.Set(Constants.Products, addedProducts);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<List<OrderProduct>> CartInfo()
    {
        var cartItems = HttpContext.Session.Get<List<OrderProduct>>(Constants.OrderProducts);
        if (cartItems.Count != 0)
        {
            ViewData["OrderProduct"] = cartItems;
            return cartItems;
        }

        return cartItems;
    }
    
    public async Task<IActionResult> ClearOrder( List<int> listId)
    {
        var order =
            HttpContext.Session.Get<List<OrderProduct>>(Constants.OrderProducts);

        var userId = await _userService.GetUserId(User.Identity.Name);
       
        var orderResult = await _orderProductService.CreateOrderProduct(order, userId);
        
       

        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}