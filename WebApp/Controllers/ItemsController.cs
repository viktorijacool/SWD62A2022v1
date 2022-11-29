using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    //are going to handle the incoming requests and outgoing responses

    public class ItemsController : Controller
    {
        //Imagine how a web page should work - a user has to click on a button twice - on the menu item and on the submit button

        private ItemsServices itemsServices;
        public ItemsController(ItemsServices _itemsServices)
        {
            itemsServices = _itemsServices;
        }

        //a method to open the page, then the user starts typing (menu item)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //a method to handle the submission of the form (submit button)
        [HttpPost]
        public IActionResult Create(CreateItemViewModel data)
        {
            itemsServices.AddItem(data);
            return View();
        }
    }
}
