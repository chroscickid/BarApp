using System.Collections.Generic;
using System.Web.Mvc;
using BrApp.Models;
using HtmlAgilityPack;

namespace BrApp.Controllers
{
     
    public class HomeController : Controller
    {
        //Whenever a drink is ordered, we create an ID for it to keep track of the total number of drinks
        private static int id = 0;
        
        //the list of drinks that are ordered
        public static List<Drink> Orders = new List<Drink>();

        //the list of drinks that can be ordered
        private static List<Drink> drinks
            = new List<Drink>()
            {
                new Drink {Name = "Margarita", Description = "Salt and tequila!!!", Price = 5},
                new Drink {Name = "Bloody Mary", Description = "Whisper it 3 times in the bathroom in the dark", Price = 7},
                new Drink {Name = "Miller Lite", Description = "It's miller time", Price = 4},
                new Drink {Name = "Water", Description = "For the designated driver", Price = 0}
                
            };

       
        //Takes the user to the front page
        public ActionResult Index()  
        {
            return View(drinks);
        }


        //The method used to place an order. It receives the value "p" from Index.cshtml
        //It then adds an ID to the drink (You can see that this is a value of the drink model in drink.cs

        public RedirectToRouteResult Order(Drink drink) 
        {
            drink.Id = ++id;
            Orders.Add(drink);
            return RedirectToAction("Index");
        }
        
    }
}

