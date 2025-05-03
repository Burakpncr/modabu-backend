using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductInStock { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public string gender { get; set; }
        public string Season { get; set; }
        public string ProductSize { get; set; }
        public bool ProductStatus { get; set; }
    }
}
