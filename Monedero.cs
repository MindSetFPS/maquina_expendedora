namespace Monedero {
    public class Monedero {
        // El monedero necesita iniciar con cierta cantidad de monedas de cada denominacion.
        // El monedero puede ejecutar una suma del dinero, una resta del cambio.

        int 1_coins;
        int 2_coins;
        int 5_coins;
        int 10_coins;
        int 20_bill;
        int 50_bill;

        int TotalMoney {
            get {
                return (1_coins * 1) + (2_coins * 2) + (5_coins * 5) + (10_coins * 10) + (20_bill * 20) + (50_bill * 50);
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

        public void GiveRemaining(){
            Console.WriteLine("To do ")
        }

    }
}