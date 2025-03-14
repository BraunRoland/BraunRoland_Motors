using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorok
{
    internal class Statisztika
    {
        List<Motor> Motorok = new List<Motor>();

        public void ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine();
            while (sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] szavak = sor.Split(";");
                Motorok.Add(new Motor(szavak[0], szavak[1], int.Parse(szavak[2]), double.Parse(szavak[3]), double.Parse(szavak[4])));
                sr.Close();
            }
        }
        public int SumPrices(string brand = null)
        {
            double sum = 0;
            foreach (var item in Motorok)
            {
                if (brand == null || item.Brand == brand)
                {
                    sum += item.PriceInEur; 
                }
            }
            return Convert.ToInt32(sum);
        }

        public bool Contains(string motorName)
        {
            foreach (var item in Motorok)
            {
                if (item.Name == motorName)
                {
                    return true;
                }
            }
            return false;
        }

        public Motor Oldest()
        {
            int ev = DateTime.Now.Year + 1;
            Motor legoregebb = null;
            foreach (var item in Motorok)
            {
                if (item.ReleaseYear < ev)
                {
                    legoregebb = item;
                    ev = item.ReleaseYear;
                }
            }
            return legoregebb;
        }

        public int SumBasedOnBrand(string brandName)
        {
            return SumPrices(brandName);
        }

        public void Sort()
        {
            Motorok.Sort((x,y) => x.Performance.CompareTo(y.Performance));
            Console.WriteLine("Motorok sorrendbe helyezve:");
            foreach (var item in Motorok)
            {
                Console.WriteLine(item);
            }
        }
    }
}
