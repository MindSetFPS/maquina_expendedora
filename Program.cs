namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Maquina.Maquina maquina = new Maquina.Maquina();
            Console.WriteLine("Hello World!");

            maquina.MachineLoop();
        }
    }
}
