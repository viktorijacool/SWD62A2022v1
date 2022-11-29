using BusinessLogic.ViewModels;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BusinessLogic.Services
{
    public class ItemsServices
    {
        //Constructor Injection
        //Dependency Injection is a design pattern which handles the creation of instances in a centralised location for better efficiency

        private ItemsRepository ir;

        public ItemsServices(ItemsRepository _itemsRepository)
        {
            ir = _itemsRepository;
        }
        public void AddItem(CreateItemViewModel item)
        {
            if (ir.GetItems().Any(i => i.Name == item.Name))                    //i is from ItemsRepository.cs; item is a parameter
                throw new Exception("Item with the same name already exists");
            else
            {
                ir.AddItem(new Domain.Models.Item()
                {
                    CategoryId = item.CategoryId,   //AutoMapper
                    Description = item.Description,
                    Name = item.Name,
                    PhotoPath = item.PhotoPath,
                    Price = item.Price,
                    Stock = item.Stock
                });
            }
        }

        public void DeleteItem(int id)
        {

        }
        public void Checkout()
        {

        }
    }
}
