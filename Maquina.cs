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

        // Creando el monedero
        Monedero.Monedero monedero = new Monedero.Monedero(
            amount_of_1_coins: 5, 
            amount_of_2_coins: 5, 
            amount_of_5_coins: 5, 
            amount_of_10_coins: 5, 
            amount_of_20_bill: 5, 
            amount_of_50_bill: 5
        );

        // Creando la lista de productos de la maquina
       List<Producto.Producto> Products = new List<Producto.Producto>(){
        new Producto.Producto (code: "A1", name: "Papitas", price: 15, stock: 10),
        new Producto.Producto (code: "A2", name: "Jugo", price: 20, stock: 10)

       };
       public int balance;
       public string Selection;

        public void MachineLoop(){
            Verify_Selection(Products);
            
        }
       public void Verify_Selection(List<Producto.Producto> productos)
       {
            string product_names = "";
            foreach (var product in productos) {
                product_names = product_names + product.code + ", ";
            }
            Console.WriteLine($"Welcome, please insert the product code you want {product_names}.");

            // Check if product is valid

            Selection = Console.ReadLine();
            
            bool codeIsInProducts = false;
            foreach (var product in productos) {
                if(product.code == Selection){
                    codeIsInProducts = true;
                    Console.WriteLine($"You want a {product.name} that costs {product.price} and has {product.stock} units.");
                } 
            }

            Producto.Producto selectedProduct = productos.Find( x => x.code == Selection);

            if (codeIsInProducts){
                Receive_Balance(selectedProduct.price);
            }

            if(!codeIsInProducts){
                Console.WriteLine("Try again");
                Verify_Selection(Products);
            }
       }

       public int Receive_Balance(double product_price)
       {
            Console.WriteLine("Please insert your balance \n The machine only accepts denominations of 5, 10, 20 and 50");

            double inserted_balance = 0;
            while (product_price > inserted_balance)
            {
                balance = int.Parse(Console.ReadLine());
                inserted_balance = inserted_balance + balance;
                Console.WriteLine($"Has insertado ${inserted_balance}");
            }

            if(inserted_balance > product_price) {
                // calcular cambio
                monedero.GiveRemaining();
            }
            return balance;
       }

    //    public bool Drop_Product()
    //    {

    //    }
            
        }
    }