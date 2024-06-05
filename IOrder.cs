using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_14
{
    public interface IOrder
    {
        void AddProduct(Product product, int quantity);
        void RemoveProduct(int ProductId, int quantity);
        decimal GetTotalPrice();
    }
}
