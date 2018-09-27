using System.Collections.Generic;
using System.Linq;
using HomeWorkMVC1.Models.Product;

namespace HomeWorkMVC1.Models.Cart
{
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; }

        public int ItemsCount
        {
            get
            {
                return Items?.Sum(x => x.Value) ?? 0;
            }
        }
    }

}
