using Dashboard_shopping_coffee.Data;
using Dashboard_shopping_coffee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.CodeAnalysis;

namespace Dashboard_shopping_coffee.Controllers.shopping
{
    public class shoppingController : Controller
    {

        private readonly ApplicationDbContext _context;

        public shoppingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var Product = _context.Products.ToList();
            return View(Product);
        }

        public IActionResult ProductDetails(int id)
        {
            var ProductDetails = _context.ProductDetails.Where(p => p.Id == id).ToList();

            return View(ProductDetails);

        }
        [Authorize]
        public IActionResult Checout(int id)
        {
            var user = HttpContext.User.Identity.Name;
            var ProductDetails = _context.ProductDetails.SingleOrDefault(p => p.Id == id);
            var cart = new Cart()
            {
                IdCostumers = user,
                MyProductId = ProductDetails.ProductId,
                Color = ProductDetails.Color,
                Images = ProductDetails.Image,
                Price = ProductDetails.Price,
                Total = ProductDetails.Price * (15 / 100) + ProductDetails.Price,
                ProductName = ProductDetails.ProductName,
                Tax = 0.15
            };
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return View(cart);
        }

       
       
        public async Task <string>SendMail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Email", "shatha.shopping2023@gmail.com")); //sender
            message.To.Add(MailboxAddress.Parse("shaz.mh24680@gmail.com")); //recvid
            message.Subject = "Test Message From My Apps";
            message.Body = new TextPart("Test")
            {
                Text="<h1>This Test Message From My Apps</h1>"
            };

            using (var clint = new SmtpClient())
            {
                try
                {
                    clint.Connect("smtp.gmail.com", 587);
                    clint.Authenticate("shatha.shopping2023@gmail.com", "lndrzbrpdhpqhjbv");
                    await clint.SendAsync(message);
                }
                catch (Exception e) { 
                    Console.WriteLine(e.Message.ToString());
                    clint.Disconnect(true);

                }

                return "Invoice";
            }

        }

       public IActionResult Invoice()
        {
            return View();
        }


    }
}
