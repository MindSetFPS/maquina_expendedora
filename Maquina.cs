using System;

namespace Maquina
{
    public class Maquina
    {
       public int A1 = 20, A2 = 15, A3 = 10;
       public int balance;
       public string Selection;

       public string  Verify_Selection()
       {
            Console.WriteLine("Welcome, please insert the product code you want. (A1,A2,A3)");
            Selection = Console.ReadLine();

            return Selection;
       }

       public int Receive_Balance()
       {
            Console.WriteLine("Please insert your balance -n\ The machine only accepts denominations of 5, 10, 20 and 50");
            balance = int.Parse(Console.ReadLine());

            return balance;
       }

       public bool Drop_Product()
       {

       }
            
            // Pasos para comprar un producto
            // 1.- Se pide al usuario que escriba el codigo de producto que desea comprar
            // 2.- Cada vez que inserte dinero, se muestra su saldo disponible, hasta igualar o superar el precio
            //     del producto seleccionado.
            // 3.- Una vez llego al saldo, se inicia la entrega del producto.
            // 4.- Si se necesita cambio, se verifica que haya suficiente.
            // 5.- Se vuelve al paso 1
        }
    }
}