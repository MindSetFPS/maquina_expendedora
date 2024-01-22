using System.Security.Authentication.ExtendedProtection;

namespace Monedero {
    public class Monedero {
        // El monedero necesita iniciar con cierta cantidad de monedas de cada denominacion.
        // El monedero puede ejecutar una suma del dinero, una resta del cambio.

        int amount_of_1_coins;
        int amount_of_2_coins;
        int amount_of_5_coins;
        int amount_of_10_coins;
        int amount_of_20_bill;
        int amount_of_50_bill;

        Monedero(int amount_of_1_coins, int amount_of_2_coins, int amount_of_5_coins, int amount_of_10_coins, int amount_of_20_bill, int amount_of_50_bill){
            this.amount_of_1_coins = amount_of_1_coins;
            this.amount_of_2_coins = amount_of_2_coins;
            this.amount_of_5_coins = amount_of_5_coins;
            this.amount_of_10_coins = amount_of_10_coins;
            this.amount_of_20_bill = amount_of_20_bill;
            this.amount_of_50_bill = amount_of_50_bill;
        }   

        int TotalMoney {
            get {
                return (amount_of_1_coins * 1) + (amount_of_2_coins * 2) + (amount_of_5_coins * 5) + (amount_of_10_coins * 10) + (amount_of_20_bill * 20) + (amount_of_50_bill * 50);
            }

            set {
                TotalMoney = value;
            }
        }

        public bool CanBuyProduct(productPrice: int){
            return TotalMoney >= productPrice;
        }

        public void BuyProduct(productPrice){
            TotalMoney = TotalMoney - productPrice
        }

        public void GiveRemaining(){   // dar cambio sabiendo cuantas monedas de cada denominacion hay que dar pero sabiendo la existencia de estas mismas monedas
            Console.WriteLine("To do ")
            if (price < balance)
            {
               int change = price - balance;
                
                if ( amount_of_1_coins == 0 && amount_of_2_coins == 0 && amount_of_5_coins == 0 && amount_of_10_coins == 0 && amount_of_20_bill == 0 && amount_of_50_bill == 0)
                {
                    Console.WriteLine("I'm sorry but at this time we do not have the coins to grant your change, try entering the exact balance.");
                }
                else
                {
                    while (change >= 50)
                    {
                        Console.WriteLine("Drop: " + amount_of_50_bill--);
                       int substraction = change - 50;
                    }
                    while (change >=20)
                    {
                        Console.WriteLine("Drop: " + amount_of_20_bill--);
                        int substraction = change - 20;
                    }
                    while (change >= 10)
                    {
                        Console.WriteLine("Drop: " + amount_of_10_coins--);
                        int substraction = change - 10;
                    }
                    while (change >= 5)
                    {
                        Console.WriteLine("Drop: " + amount_of_5_coins--);
                        int substraction = change - 5;
                    }
                    while (change >= 2)
                    {
                        Console.WriteLine("Drop: " + amount_of_2_coins--);
                        int substraction = change - 2;
                    }
                    while (change >= 1)
                    {
                        Console.WriteLine("Drop: " + amount_of_1_coins--);
                        int substraction = change - 1;
                    }
                }
            }
            
        }

    }
}
