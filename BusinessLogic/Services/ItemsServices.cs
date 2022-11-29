using BusinessLogic.ViewModels;
using DataAccess.Repositories;
using Domain.Models;
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

        //it is not recommended that you use the Domain Models as a return type
        //in other words, do not use the classes that model the database to transfer data into the presentation layer

        //Item contains all necessary data from the database
        //ItemViewModel is used to display a certain info from the database
        public IQueryable<ItemViewModel> GetItems()
        {
            var list = from i in ir.GetItems()
                       select new ItemViewModel()
                       {
                           Id = i.Id,
                           Category = i.Category.Title,
                           Description = i.Description,
                           Name = i.Name,
                           PhotoPath = i.PhotoPath,
                           Price = i.Price,
                           Stock = i.Stock
                       };
            return list;
        }

        //Filter 
        public IQueryable<ItemViewModel> Search(string keyword)
        {
            return GetItems().Where(x => x.Name.Contains(keyword));
        }

        public IQueryable<ItemViewModel> Search(string keyword, double minPrice, double maxPrice)
        {
            return Search(keyword).Where(x=> x.Price < minPrice && x.Price > maxPrice);
        }

        
        public ItemViewModel GetItem(int id)
        {
            return GetItems().SingleOrDefault(x => x.Id == id);
        }
    }
}
