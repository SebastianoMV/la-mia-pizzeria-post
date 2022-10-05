using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace la_mia_pizzeria_post.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        { 
            return View(Pizze());
        }

        public IActionResult Details(int id)
        {
            return View(Pizze()[id]);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pizza);
            }
            Aggiungi(new Pizza(pizza.Nome, pizza.Descrizione, pizza.Image, pizza.Prezzo));
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

        public List<Pizza> Pizze()
        {
            Context db = new Context();
            List<Pizza> pizze = db.Pizza.OrderBy(pizza => pizza.Id).ToList<Pizza>();
            return pizze;
        }


        public void Aggiungi(Pizza pizza)
        {
            Context db = new Context();
            db.Add(pizza);
            db.SaveChanges();
        }

    }
}