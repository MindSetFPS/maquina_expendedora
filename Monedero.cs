namespace Monedero
{
    public class Monedero
    {
        // El monedero necesita iniciar con cierta cantidad de monedas de cada denominacion.
        // El monedero puede ejecutar una suma del dinero, una resta del cambio.
        List<Dinero.Dinero> available_denominations;
        public Monedero(List<Dinero.Dinero> dineros)
        {
            // sort list from greater value to lower value
            this.available_denominations = dineros.OrderByDescending(money => money.valor).ToList();
        }

        int TotalMoney
        {
            get
            {
                int sum = 0;
                foreach (Dinero.Dinero money in available_denominations)
                {
                    sum = sum + (money.cantidad * money.valor);
                }
                return sum;
            }

            set
            {
                TotalMoney = value;
            }
        }

        public bool CanBuyProduct(int productPrice)
        {
            return TotalMoney >= productPrice;
        }

        public void BuyProduct(int productPrice)
        {
            TotalMoney = TotalMoney - productPrice;
        }
        // Dar cambio considerando cuantas monedas de cada denominacion existen actualemente dentro de la maquina.
        public void GiveRemaining(double price, double balance)
        {
            // Console.WriteLine(String.Join(", ", available_denominations));
            if (price == balance)
            {
                Console.WriteLine("La maquina entrega el producto.");
            }

            if (TotalMoney == 0)
            {
                Console.WriteLine("I'm sorry but at this time we do not have the coins to grant your change, try entering the exact balance.");
            }

            if (price < balance)
            {
                double total_change = balance - price;

                Console.WriteLine($"Precio del producto: ${price}");
                Console.WriteLine($"Cambio a dar: {balance} - {price} = {balance - price}");
                // double cambio_en_monedas = 0;

                if (total_change > TotalMoney)
                {
                    Console.WriteLine("No hay cambio. Te regreso tu dinero.");
                }
                double current_change = total_change;
                double accumulated_change = 0;

                // compre algo de 15 y pague con uno de 50
                foreach (Dinero.Dinero money in available_denominations)
                {
                    // Console.WriteLine($"{money.tipo} de {money.valor}");
                    // cambio = 35
                    while( money.valor <= current_change && money.cantidad > 0) {
                        Console.WriteLine($"Te doy 1 {money.tipo} de {money.valor} ");
                        current_change = current_change - money.valor;
                        accumulated_change = accumulated_change + money.valor;
                    }
                }
                Console.WriteLine($"Cambio restante: {current_change}");
                Console.WriteLine($"Cambio dado: {accumulated_change}");
                

                // while(cambio_en_monedas != total_change){
                //     if(cambio_en_monedas >= 50){ 
                //         amount_of_50_bill = amount_of_50_bill  -1;
                //         cambio_en_monedas = cambio_en_monedas + 50;
                //     }

                //     if(cambio_en_monedas >= 20){
                //         amount_of_20_bill = amount_of_20_bill -1;
                //         cambio_en_monedas = cambio_en_monedas + 20;
                //     }
                // }
            }
        }
    }
}