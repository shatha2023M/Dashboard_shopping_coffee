using Dashboard_shopping_coffee.Data;
using Dashboard_shopping_coffee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dashboard_shopping_coffee.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpPost]
        public IActionResult Index(string ProductName)
        {
            var products = context.Products.Where(x => x.ProductName.Contains(ProductName)).ToList();
            TempData["search"] = "VIEW ALL";
            return View(products);
        }

        [Authorize]
        public IActionResult Index()
        {
            var Name = HttpContext.User.Identity.Name;
            //CookieOptions options = new CookieOptions();
            //options.Expires = DateTime.Now.AddMinutes(10);
            //Response.Cookies.Append("Name",Name,options);

            //HttpContext.Session.SetString("Name", Name);

            TempData["Name"] = Name;
            var product = context.Products.ToList();
            ViewBag.Name = Name;
            return View(product);
        }

        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        public IActionResult UpdateProducts(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ProductDetails()
        {
            var Product = context.Products.ToList();
            var ProductDetails = context.ProductDetails.ToList();
            ViewBag.ProductDetails = ProductDetails;
            TempData["search"] = "VIEW ALL";
            return View(Product);
            
        }

        public IActionResult AddProductDetails(ProductDetails ProductDetails)
        {
            context.ProductDetails.Add(ProductDetails);
            context.SaveChanges();
            return RedirectToAction("ProductDetails");
        }

        [HttpPost]
        public IActionResult ProductDetails(int id)
        {
            var ProductDetails = context.ProductDetails.Where(p => p.ProductId == id).ToList();
            var Product = context.Products.ToList();
            ViewBag.ProductDetails = ProductDetails;
            return View(Product);
        }

        public IActionResult DeleteDetails(int id)
        {
            var productDetails = context.ProductDetails.SingleOrDefault(p => p.Id == id);
            if (productDetails != null)
            {
                context.ProductDetails.Remove(productDetails);
                context.SaveChanges();
            }

            return RedirectToAction("ProductDetails");
        }

        public IActionResult EditDetails(int id)
        {
            var productDetails = context.ProductDetails.SingleOrDefault(x => x.Id == id);
            return View(productDetails);
        }
        public IActionResult UpdateDetails(ProductDetails ProductDetails)
        {
            context.ProductDetails.Update(ProductDetails);
            context.SaveChanges();
            return RedirectToAction("ProductDetails");
        }

        public IActionResult PaymentAccept()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentAccept(PaymentAccept PaymentAccept)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
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