using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }       
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Items { get; set; }      
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string BuyerPhone { get; set; }
        public string BuyerAddress { get; set; }

    }
}
