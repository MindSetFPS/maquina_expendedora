using System;
using System.Diagnostics;
using Producto;

namespace Maquina
{
    public class Maquina
    {
        // Pasos para comprar un producto
        // 1.- Se pide al usuario que escriba el codigo de producto que desea comprar
        // 2.- Cada vez que inserte dinero, se muestra su saldo disponible, hasta igualar o superar el precio
        //     del producto seleccionado.
        // 3.- Una vez llego al saldo, se inicia la entrega del producto.
        // 4.- Si se necesita cambio, se verifica que haya suficiente.
        // 5.- Se vuelve al paso 1

        public string SelectedProductCode;
        public int balance;
        // Creando el monedero
        Monedero.Monedero monedero = new Monedero.Monedero([
            new Dinero.Dinero(valor: 1, cantidad: 50, tipo: "Moneda"),
            new Dinero.Dinero(valor: 2, cantidad: 50, tipo: "Moneda"),
            new Dinero.Dinero(valor: 5, cantidad: 50, tipo: "Moneda"),
            new Dinero.Dinero(valor: 10, cantidad: 0, tipo: "Moneda"),
            new Dinero.Dinero(valor: 20, cantidad: 0, tipo: "billete"),
            new Dinero.Dinero(valor: 50, cantidad: 0, tipo: "billete"),
        ]);

        // Creando la lista de productos de la maquina
        List<Producto.Producto> Products = new List<Producto.Producto>(){
            new Producto.Producto (code: "A1", name: "Papitas", price: 15, stock: 10),
            new Producto.Producto (code: "A2", name: "Jugo de Naranja", price: 20, stock: 10),
            new Producto.Producto (code: "A3", name: "Café con leche", price: 35, stock: 10),
            new Producto.Producto (code: "A4", name: "Mantecadas", price: 28, stock: 10),
            new Producto.Producto (code: "B1", name: "Bizcochitos", price: 12, stock: 1),
            new Producto.Producto (code: "B2", name: "Gansito", price: 21, stock: 10),
       };

        public void MachineLoop(){
            while(true){
                ShowProducts();
                Verify_SelectedProductCode(Products);
                Thread.Sleep(6000);
                Console.Clear();    
            }
        }

        public void ShowProducts(){

            string accepts = "Acepta denominacion de ";
            foreach(Dinero.Dinero dinero in monedero.available_denominations){
                accepts = accepts + "$" + dinero.valor + " ";
            }
            Console.WriteLine(accepts);
            foreach(Producto.Producto product in Products){
                Console.WriteLine($"Codigo: {product.code} - {product.name} - ${product.price} - Stock:{product.stock}");
            }
        }
        public void Verify_SelectedProductCode(List<Producto.Producto> productos) {
            SelectedProductCode = Console.ReadLine();

            Producto.Producto selectedProduct = productos.Find(product => product.code == SelectedProductCode);

            if (selectedProduct == null || selectedProduct.stock == 0){
                Console.WriteLine("Try again");
                Verify_SelectedProductCode(Products);
            } else {
                bool dropProduct = Receive_Balance(selectedProduct.price);

                if (dropProduct){
                    UpdateStock(selectedProduct);
                }
            }
        }

        public bool Receive_Balance(double product_price){
            Console.WriteLine("Please insert your balance");
            double inserted_balance = 0;
            while (product_price > inserted_balance){
                balance = int.Parse(Console.ReadLine());
                string balanceIsInDenominations = (monedero.ReceivedBalanceIsInDenominations(inserted_balance: balance)) ? "si" : "no";
                // Console.WriteLine($"{balance} {balanceIsInDenominations} está en la lista de denominaciones");
                if(monedero.ReceivedBalanceIsInDenominations(inserted_balance: balance)){
                    inserted_balance = inserted_balance + balance;
                    Console.WriteLine($"Has insertado ${inserted_balance}");
                } else {
                    Console.WriteLine("No aceptamos esa denominacion. Prueba con otra.");
                }
            }

            bool dropProduct = false;
            if (inserted_balance == product_price){
                Console.WriteLine("Entregar producto");
                dropProduct = true;
            }

            if (inserted_balance > product_price){
                // No hay cambio
                if (monedero.TotalMoney == 0){
                    Console.WriteLine("I'm sorry but at this time we do not have the coins to grant your change, try entering the exact balance.");
                } else {
                    // calcular cambio
                    dropProduct = monedero.CanGiveChange(price: product_price, balance: inserted_balance);
                }
            }
            return dropProduct;
        }

        public void UpdateStock(Producto.Producto producto){
            producto.stock = producto.stock - 1;
        }
    }
}