﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//This is my basket view model. It has the functions for my basket
namespace SteveBookStore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Books proj, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Books.BookId == proj.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = proj,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Books proj)
        {
            Items.RemoveAll(b => b.Books.BookId == proj.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(b => b.Quantity * b.Books.Price);

            return sum;
        }
    }

    
    public class BasketLineItem 
    { 
        [Key]
        public int LineID { get; set; }
        public Books Books { get; set; }
        public int Quantity { get; set; }
    }

}
