﻿using System;
using SQLite;
using Xamarin.Forms;
namespace ICT13580026A2.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Cateory { get; set; }

        public decimal ProductPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Stock { get; set; }

        public static implicit operator MenuItem(Product v)
        {
            throw new NotImplementedException();
        }
    }
}
