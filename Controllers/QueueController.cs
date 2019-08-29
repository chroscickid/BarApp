using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BrApp.Models;

namespace BrApp.Controllers
{
   
    public class QueueController : Controller
    {
        //Creates a list of ready drinks
        private static List<Drink> ready = new List<Drink>();

        //Shows the ViewOrders.cshtml view
        public ActionResult ViewOrders () 

        {
            return View(HomeController.Orders);
        }

        //This method is called from the "View Orders Table"
        //First, we add the "drink" item that we passed through to the list of prepared drinks
        //Then we remove it from the list of pending orders
       public RedirectToRouteResult Prepare(Drink drink)
        {
            ready.Add(drink);

            
            var send = HomeController.Orders.Where(x => x.Id == drink.Id); // x rep an object in Orders            
            HomeController.Orders.Remove(send.FirstOrDefault());

            return RedirectToAction("ViewOrders");  
        }

        //This removes the "drink" item from the list of pending orders, without doing anything else
        public RedirectToRouteResult Cancel(Drink drink)
        {
            var cancel = HomeController.Orders.Where(x => x.Id == drink.Id);             
            HomeController.Orders.Remove(cancel.FirstOrDefault());

            return RedirectToAction("ViewOrders");
        }





        public ActionResult ViewPrepared() 

        {
            return View(ready); 
        }

        
        public RedirectToRouteResult Served(Drink drink)
        {
            ready.RemoveAll(x => x.Id == drink.Id);
            return RedirectToAction("ViewPrepared");
        }

    }
}