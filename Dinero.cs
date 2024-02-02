
namespace Dinero
{
    public class Dinero
    {
        public uint valor;
        public uint cantidad;
        public string tipo;

        public Dinero(uint valor, uint cantidad, string  tipo){
            this.valor = valor;
            this.cantidad = cantidad;
            this.tipo = tipo;
        }

        public Dinero Clone(){
            return new Dinero(
                valor = this.valor,
                cantidad = this.cantidad,
                tipo = this.tipo
            );
        } 

    }
}