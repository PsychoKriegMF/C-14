using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_14
{
    public class Order : IOrder
    {
        protected List<OrderItem> items = new List<OrderItem>();
        public void AddProduct(Product product, int quantity)
        {
            var existingItem = items.FirstOrDefault(e => e.Product.ID == product.ID);
            if(existingItem.Product.ID != 0)
            {
                 items.Remove(existingItem);
                existingItem.Quantity += quantity;
                items.Add(existingItem);
            }
            else
            {
                items.Add(new OrderItem { Product = product, Quantity = quantity });
            }
        }
        public void RemoveProduct(int ProductId, int quantity)
        {
            items.RemoveAll(e => e.Product.ID == ProductId);
        }
        public decimal GetTotalPrice()
        {
            return items.Sum(e => e.Product.Price * e.Quantity);
        }
        public List<OrderItem> GetOrderItems()
        {
            return items;
        }
    }
}
