using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string PhotoPath { get; set; }

        public int Stock { get; set; }
    }
}
