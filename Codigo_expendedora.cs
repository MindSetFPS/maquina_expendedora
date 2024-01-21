using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensador1
{
    public class producto
    {
        public List<Producto> Productos { get; set; }

        public string pago { get; set; }
        public double Cambio { get; set; }
        public int valor { get; set; }
        public int cantidad { get; set; }

        public Dispensadora()
        {
            this.Productos = new List<Producto>();
            Producto chocolate = new Producto();
            chocolate.codigo = "01";
            chocolate.Nombre = "chocolate";
            chocolate.Categoria = "hershey";
            chocolate.Cantidad = 12;
            chocolate.Valor = 50 ;

            Producto galletas = new Producto();
            galletas.codigo = "02";
            galletas.Nombre = "Princesa";
            galletas.Categoria = "saladas";
            galletas.Cantidad = 12;
            galletas.Valor = 200;

            Producto refresco = new Producto();
            refresco.codigo = "03";
            refresco.Nombre = "coca-cola";
            refresco.Categoria = "medio_litro";
            refresco.Cantidad = 12;
            refresco.Valor = 15;

            Producto jugo = new Producto();
            jugo.codigo = "04";
            jugo.Nombre = "jugo";
            jugo.Categoria = "jugo_natural";
            jugo.Cantidad = 14;
            jugo.Valor = 30;

            Producto doritos = new Producto();
            doritos.codigo = "05";
            doritos.Nombre = "doritos";
            doritos.Categoria = "frito_lay";
            doritos.Cantidad = 12;
            doritos.Valor = 15;

            Producto agua = new Producto();
            agua.codigo = "06";
            agua.Nombre = "agua";
            agua.Categoria = "planeta_azul";
            agua.Cantidad = 19;
            agua.Valor = 20;

            Producto cheetos = new Producto();
            cheetos.codigo = "07";
            cheetos.Nombre = "cheetos";
            cheetos.Categoria = "frito_lay";
            cheetos.Cantidad = 15;
            cheetos.Valor = 30;

            Producto chicharon = new Producto();
            chicharon.codigo = "08";
            chicharon.Nombre = "chicharon";
            chicharon.Categoria = "frito_lay";
            chicharon.Cantidad = 20;
            chicharon.Valor = 30;

            Producto yogur = new Producto();
            yogur.codigo = "09";
            yogur.Nombre = "yogur";
            yogur.Categoria = "yoka";
            yogur.Cantidad = 25;
            yogur.Valor = 35;

            Producto agua_saborizada = new Producto();
            agua_saborizada.codigo = "10";
            agua_saborizada.Nombre = " agua_saborizada";
            agua_saborizada.Categoria = "dasani";
            agua_saborizada.Cantidad = 25;
            agua_saborizada.Valor = 50;






            this.Productos.Add(chocolate);
            this.Productos.Add(galletas);
            this.Productos.Add(refresco);
            this.Productos.Add(jugo);
            this.Productos.Add(doritos);
            this.Productos.Add(agua);
            this.Productos.Add(cheetos);
            this.Productos.Add(chicharon);
            this.Productos.Add(yogur);
            this.Productos.Add(agua_saborizada);
        }

        public int validaProducto(string codigo) // este metodo es para validar si encontro si existe el ptoducto
        {
            int enc = -1; // par encontar el producto 



            for (int i = 0; i < this.Productos.Count; i++)
            {
                if (this.Productos[i].codigo == codigo)
                {
                    enc = i;
                }
            }


            return enc;
        }

        public bool agreProducto(Producto producto)  // esto es por si se acaba un producto o quieren agregar un nuevo producto lod admin de la maquina
        {
            int encon = this.validaProducto(producto.codigo);
            if (encon >= 0)
            {
                this.Productos[encon].SumarCantidad(producto.Cantidad);
            }
            else
            {
                this.Productos.Add(producto);
            }
            return true;

        }

        public bool eliminarProducto(string codigo)
        {
            int encon = this.validaProducto(codigo);

            if (encon >= 0)
            {
                this.Productos[encon].RemoveAt(encon);
                return true;
            }

            return false;

        }


        public double validarDinero(string[] dinero)
        {
            double total = 0;
            foreach (string item in dinero)
            {
                try
                {
                    total += double.Parse(item);

                }
                catch (Exception e) { }

            }

            return total;
        }

        // 200-100-50-25-10-5 dinero


        public Producto Vender(string codigo)
        {
            int encon = this.validaProducto(codigo);
            if (encon >= 0)
            {
                if (this.Productos[encon].Validarcantodad())
                {

                    string[] dinero = this.pago.Split('-');

                    double total = this.validarDinero(dinero);

                    if (this.Productos[encon].validarValor(total))
                    {
                        this.Productos[encon].restarProductos();
                        return this.Productos[encon];

                    }

                }
            }

            return null; //si no hay un producto entonces es nulo
        }

        public string listaProducto()
        {
            string lista = "";
            foreach (Producto item in this.Productos)
            {
                lista += item.codigo + " " + item.Nombre + " " + item.Categoria + " " + item.Cantidad + " " + item.Valor + "\n";
            }
            return lista;
        }


    }
}




namespace Dispensador1
{
    public class Producto
    {
        public string codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
        public double Cambio { get; set; }

        public void SumarCantidad(int cantidad)
        {
            this.Cantidad += cantidad;
        }

        public bool Validarcantodad()
        {
            if (this.Cantidad > 0)
            {
                return true;
            }
            return false;
        }

        public bool validarValor(double valor)
        {
            if (this.Valor <= valor)
            {
                this.Cambio = valor - this.Valor;
                return true;
            }
            return false;
        }

        public void restarProductos()
        {
            this.Cantidad--;
        }

        internal void RemoveAt(int encon)
        {

        }


    }



    class Program
    {
        static void Main(string[] args)
        {
            Dispensadora dispensador = new Dispensadora();

            Console.WriteLine("Bienvenido a la dispensadora ITLA");



            while (true)
            {


                Console.WriteLine(dispensador.listaProducto());

                Console.WriteLine(" 1. apregar producto");
                Console.WriteLine(" 2. Eliminar producto ");
                Console.WriteLine(" 3. Comprar producto  ");
                string opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":
                        Producto producto = new Producto();
                        Console.WriteLine("codigo ");
                        producto.codigo = Console.ReadLine();

                        Console.WriteLine("nombre ");
                        producto.Nombre = Console.ReadLine();

                        Console.WriteLine("Categoria ");
                        producto.Categoria = Console.ReadLine();

                        Console.WriteLine("cantidad ");
                        producto.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Valor ");
                        producto.Valor = double.Parse(Console.ReadLine());

                        dispensador.agreProducto(producto);

                        break;

                    case "2":
                        Console.WriteLine(" codigo ");
                        string codigo = Console.ReadLine();

                        dispensador.eliminarProducto(codigo);
                        break;

                    case "3":
                        Console.WriteLine(" codigo");
                        string codigo_venta = Console.ReadLine();

                        Console.WriteLine(" Dinero solo de (200-100-50-25-10-5) ");
                        dispensador.pago = Console.ReadLine();

                        Producto preComprado = dispensador.Vender(codigo_venta);

                        if (preComprado == null)
                        {
                            Console.WriteLine(" No se pudo sacar el producto");
                        }
                        else
                        {
                            Console.WriteLine(" su producto es {0} y la devuelta es {1}", preComprado.codigo, preComprado.Cambio);
                        }

                        break;
                }

                Console.WriteLine(" Desea continuar si/no");
                if (Console.ReadLine() == "no")
                {
                    break;
                }
            }


        }
    }
}