using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNangcao.Models
{
    public class CartModel
    {
        public int productId { get; set; }

        public SanPham ProductDetail { get; set; }
        
        public int quantity { get; set; }  

        public double amount { get; set; }
    }
}