namespace motorok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Statisztika statisztika = new Statisztika();
            statisztika.ReadFromFile("motors.txt");
            Console.Write("Beolvasás kész!");
            Console.WriteLine($"A motorok összára: {statisztika.SumPrices()} EUR");
            Console.Write("Addj meg egy márkát: ");
            string marka = Console.ReadLine();
            Console.WriteLine($"A(z){marka} márka megtalálható a listában: {statisztika.Contains(marka)}");
            Console.WriteLine($"A legrégebbi motor: {statisztika.Oldest()}");
            Console.Write("Addj meg egy márkát: ");
            marka = Console.ReadLine();
            Console.WriteLine($"A(z) {marka} márkájú motorok összára: {statisztika.SumBasedOnBrand(marka)}");
            statisztika.Sort();
        }
    }
}
