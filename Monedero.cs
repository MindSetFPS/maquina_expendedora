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

        public Monedero(int amount_of_1_coins, int amount_of_2_coins,int amount_of_5_coins,int amount_of_10_coins,int amount_of_20_bill,int amount_of_50_bill){
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

        public bool CanBuyProduct(int productPrice){
            return TotalMoney >= productPrice;
        }

        public void BuyProduct(int productPrice){
            TotalMoney = TotalMoney - productPrice;
        }

        public void GiveRemaining(){
            Console.WriteLine("To do ");
        }

    }
}