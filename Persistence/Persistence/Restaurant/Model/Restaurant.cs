using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.BurgerRestaurant.Model
{
    [Table(name: "Restaurant")]
    public class Restaurant
    {
        [Key]
        [Column(name: "ID")]
        public int ID { get; set; }

        [Column(name: "Name")]
        public string Name { get; set; }

        [Column(name: "Phone")]
        public int Phone { get; set; }

        [Column(name: "Address")]
        public string Address { get; set; }
    }
}