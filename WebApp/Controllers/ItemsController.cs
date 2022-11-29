using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApp.Controllers
{
    //are going to handle the incoming requests and outgoing responses

    public class ItemsController : Controller
    {
        //Imagine how a web page should work - a user has to click on a button twice - on the menu item and on the submit button

        private ItemsServices itemsService;
        public ItemsController(ItemsServices _itemsService)
        {
            itemsService = _itemsService;
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
            try
            {
                itemsService.AddItem(data);

                //dynamic object - it builds the declared properties on-the-fly i.e. the moment you declare the property
                //"Message" - it builds in realtime in memory
                ViewBag.Message = "Item successfully inserted in database";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Item wasn't inserted successfully. Please check your inputs";
            }
            return View();
        }
    }
}
