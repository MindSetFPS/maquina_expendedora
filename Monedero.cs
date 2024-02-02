namespace Monedero{
    public class Monedero{
        // El monedero necesita iniciar con cierta cantidad de monedas de cada denominacion.
        // El monedero puede ejecutar una suma del dinero, una resta del cambio.
        List<Dinero.Dinero> available_denominations;
        List<Dinero.Dinero> new_available_denominations;

        public Monedero(List<Dinero.Dinero> dineros){
            // sort list from greater value to lower value
            this.available_denominations = dineros.OrderByDescending(money => money.valor).ToList();
            this.new_available_denominations = [];
        }

        public uint TotalMoney{
            get{
                uint sum = 0;
                foreach (Dinero.Dinero money in available_denominations){
                    sum = sum + (money.cantidad * money.valor);
                }
                return sum;
            }

            set{
                TotalMoney = value;
            }
        }

        public bool CanBuyProduct(double productPrice){
            return TotalMoney >= productPrice;
        }

        public bool ReceivedBalanceIsInDenominations(int inserted_balance){
            bool comparison = false;
            foreach(Dinero.Dinero denomination in available_denominations){
                comparison = denomination.valor == inserted_balance;
                Console.WriteLine($"{inserted_balance} == {denomination.valor} {comparison}");

                if(comparison){
                    break;
                }
            }
            return comparison;
        }

        public bool CanGiveChange(double price, double balance){
                double total_change = balance - price; //35
                // List<Dinero.Dinero> available_denominations_copy = [];
                double current_change = total_change; // 15
                uint accumulated_change = 0; //0

                // Print Original
                Console.WriteLine($"Original");
                foreach(Dinero.Dinero money in available_denominations){
                    // available_denominations_copy.Add(money.Clone());
                    Console.WriteLine($"{money.valor} {money.cantidad} {money.tipo}");
                }

                // Populate copy with elements
                foreach(Dinero.Dinero money in available_denominations){
                    new_available_denominations.Add(money.Clone());
                    // Console.WriteLine($"{money.valor} {money.cantidad} {money.tipo}");
                }

                // Print copy
                Console.WriteLine($"Copy");
                foreach (Dinero.Dinero money in new_available_denominations){
                    while( money.valor <= current_change && money.cantidad > 0) {
                        // Console.WriteLine($"Te doy 1 {money.tipo} de {money.valor} ");
                        current_change = current_change - money.valor;
                        accumulated_change = accumulated_change + money.valor;
                        money.cantidad = money.cantidad - 1;   
                    }
                    Console.WriteLine($"{money.valor} {money.cantidad} {money.tipo}");
                }            

                available_denominations = [];
                // available_denominations = new_available_denominations ;


                Console.WriteLine($"{current_change} {accumulated_change}");

                if(accumulated_change < total_change){
                    Console.WriteLine($"no hay suficiente cambio");
                }

                Console.ReadLine();

                return accumulated_change >= total_change;
        }

        public void BuyProduct(int productPrice)
        {
            TotalMoney = TotalMoney - (uint) productPrice;
        }
        // Dar cambio considerando cuantas monedas de cada denominacion existen actualemente dentro de la maquina.
        public void GiveRemaining(double price, double balance){

            if (price < balance){
                double total_change = balance - price;
                double current_change = total_change;
                double accumulated_change = 0;

                Console.WriteLine($"Precio del producto: ${price}");
                Console.WriteLine($"Cambio a dar: {balance} - {price} = {balance - price}");

                if (total_change > TotalMoney){
                    Console.WriteLine("No hay cambio. Te regreso tu dinero.");
                }

                // compre algo de 15 y pague con uno de 50
                foreach (Dinero.Dinero money in available_denominations){
                    while( money.valor <= current_change && money.cantidad > 0) {
                        Console.WriteLine($"Te doy 1 {money.tipo} de {money.valor} ");
                        current_change = current_change - money.valor;
                        accumulated_change = accumulated_change + money.valor;
                        money.cantidad = money.cantidad - 1;   
                    }
                }

                if(accumulated_change < total_change){
                    Console.WriteLine($"no hay suficiente cambio");
                } else {
                    Console.WriteLine($"Cambio restante: {current_change}");
                    Console.WriteLine($"Cambio dado: {accumulated_change}");
                }

                foreach (Dinero.Dinero money in available_denominations){
                    Console.WriteLine($"{money.valor} = {money.cantidad} {money.tipo}");
                }
            }
        }
    }
}