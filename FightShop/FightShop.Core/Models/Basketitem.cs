using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShop.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BasketD { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
