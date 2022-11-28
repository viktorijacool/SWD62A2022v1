using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]                     //constraints
        [Required]
        public string Name { get; set; }

        [ForeignKey("Category")]                //need to apply a navigational property's name to a foreign key
        public int CategoryId { get; set; }
        public Category Category { get; set; }  //a navigational property

        public double Price { get; set; }

        public string Description { get; set; }

        public string PhotoPath { get; set; }

        public int Stock { get; set; }
    }
}
