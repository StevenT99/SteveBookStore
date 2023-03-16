using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveBookStore.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }
        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please Enter A Name")]
        public string Name { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Please Enter A City Name")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Please Enter A State Name")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please Enter A Country")]
        public string Country { get; set; }

        public bool Anonymous { get; set; }



    }
}
