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
            new Dinero.Dinero(valor: 1, cantidad: 5, tipo: "Moneda"),
            new Dinero.Dinero(valor: 2, cantidad: 5, tipo: "Moneda"),
            new Dinero.Dinero(valor: 5, cantidad: 5, tipo: "Moneda"),
            new Dinero.Dinero(valor: 10, cantidad: 5, tipo: "Moneda"),
            new Dinero.Dinero(valor: 20, cantidad: 5, tipo: "billete"),
            new Dinero.Dinero(valor: 50, cantidad: 5, tipo: "billete"),
        ]);

        // Creando la lista de productos de la maquina
        List<Producto.Producto> Products = new List<Producto.Producto>(){
            new Producto.Producto (code: "A1", name: "Papitas", price: 15, stock: 10),
            new Producto.Producto (code: "A2", name: "Jugo de Naranja", price: 20, stock: 10),
            new Producto.Producto (code: "A3", name: "Café con leche", price: 35, stock: 10),
            new Producto.Producto (code: "A4", name: "Mantecadas", price: 28, stock: 10),
            new Producto.Producto (code: "B1", name: "Bizcochitos", price: 12, stock: 10),
            new Producto.Producto (code: "B2", name: "Gansito", price: 21, stock: 10),
       };

        public void MachineLoop(){
            while(true){
                ShowProducts();
                Verify_SelectedProductCode(Products);
                // Thread.Sleep(6000);
                Console.ReadLine();
                Console.Clear();    
            }
        }

        public void ShowProducts(){
            foreach(Producto.Producto product in Products){
                Console.WriteLine($"Codigo: {product.code} - {product.name} - ${product.price}");
            }
        }
        public void Verify_SelectedProductCode(List<Producto.Producto> productos)
        {
            string product_names = "";
            foreach (var product in productos)
            {
                product_names = product_names + product.code + ", ";
            }
            // Console.WriteLine($"Welcome, please insert the product code you want {product_names}.");

            // Check if product is valid

            SelectedProductCode = Console.ReadLine();

            bool codeIsInProducts = false;
            foreach (var product in productos)
            {
                if (product.code == SelectedProductCode)
                {
                    codeIsInProducts = true;
                    Console.WriteLine($"You want a {product.name} that costs {product.price} and has {product.stock} units.");
                    break;
                }
            }

            Producto.Producto selectedProduct = productos.Find(product => product.code == SelectedProductCode);

            if (codeIsInProducts)
            {
                Receive_Balance(selectedProduct.price);
            }

            if (!codeIsInProducts)
            {
                Console.WriteLine("Try again");
                Verify_SelectedProductCode(Products);
            }
        }


        public int Receive_Balance(double product_price)
        {
            Console.WriteLine("Please insert your balance \n The machine only accepts denominations of 5, 10, 20 and 50");
            double inserted_balance = 0;
            while (product_price > inserted_balance)
            {
                balance = int.Parse(Console.ReadLine());
                string balanceIsInDenominations = (monedero.ReceivedBalanceIsInDenominations(inserted_balance: balance)) ? "si" : "no";
                Console.WriteLine($"{balance} {balanceIsInDenominations} está en la lista de denominaciones");
                if(monedero.ReceivedBalanceIsInDenominations(inserted_balance: balance)){
                    inserted_balance = inserted_balance + balance;
                    Console.WriteLine($"Has insertado ${inserted_balance}");
                } else {
                    Console.WriteLine("No aceptamos esa denominacion. Prueba con otra.");
                }
            }

            if (inserted_balance == product_price)
            {
                Console.WriteLine("Entregar producto");
            }

            if (inserted_balance > product_price)
            {
                // No hay cambio
                if (monedero.TotalMoney == 0){
                    Console.WriteLine("I'm sorry but at this time we do not have the coins to grant your change, try entering the exact balance.");
                } else {
                    // calcular cambio
                    monedero.CanGiveChange(price: product_price, balance: inserted_balance);
                    // monedero.GiveRemaining(price: product_price, balance: inserted_balance);
                }
            }
            return balance;
        }
    }
}