using System;

namespace Producto
{
    public class Producto
    {
        public string name;
        public double price;
        public string code;
        public int stock;

        public Producto(string name, double price, string code, int stock) {
            this.name = name;
            this.price = price;
            this.code = code;
            this.stock = stock;
        }   
    
    }
}