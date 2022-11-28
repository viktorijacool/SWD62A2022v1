﻿using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class ShoppingCartContext : IdentityDbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) 
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }          // an abstarction of tables so in plural
        public DbSet<Category> Categories { get; set; }

    }
}
