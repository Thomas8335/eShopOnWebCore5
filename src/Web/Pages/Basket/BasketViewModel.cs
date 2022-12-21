using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.Web.Pages.Basket
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public string BuyerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }

        public decimal Tax()
        {
            var taxRate = 0.06M;
            var beforeTax = Total();
            var taxAmount = beforeTax * taxRate;
            return taxAmount;

        }

        public decimal GrandTotal()
        {
            var total = Total();
            var taxAmount = Tax();
            return total + taxAmount;
        }
    }
}
