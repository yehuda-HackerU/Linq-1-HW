using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_1_HW
{
    class City
    {
        internal string CityName { get; set; }
        internal int Population { get; set; }

        public City(string cityName, int population)
        {
            CityName = cityName;
            Population = population;
        }

        public override string ToString()
        {
            return CityName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Numbers Query

            List<int> numbers = new List<int>() { 1, -11, 6, 10, -50, 2, 7, -8, 5, -5, 15, 48, 55 };
            IEnumerable<int> query;
            #region Ex1
            query = numbers.Where(x => x < 0);
            #endregion

            #region Ex2
            query = numbers.Where(x => x % 2 == 0).OrderByDescending(x => x);
            #endregion

            #region Ex3
            query = numbers.Where(x => x > 5 && x % 3 != 0).Select(x => x * 3);
            #endregion

            foreach (int num in query)
            {
                Console.WriteLine(num);
            }

            #endregion

            List<City> citiesList = new List<City>()
            {
                new City("New York", 8550405),
                new City("Los Angeles", 3971883),
                new City("Chicago", 2720546),
                new City("Houston", 2296224),
                new City("Philadelphia", 1567442),
                new City("Phoenix", 1563025),
                new City("San Antonio", 1469845),
                new City("San Diego", 1394928),
                new City("Dallas", 1300092),
                new City("San Jose", 1026908),
                new City("Austin", 931830),
                new City("Jacksonville", 868031),
                new City("San Francisco", 864816),
                new City("Indianapolis", 853173),
                new City("Columbus", 850106),
                new City("Fort Worth", 833319),
                new City("Charlotte", 827097),
                new City("Seattle", 684451),
                new City("Denver", 682545),
                new City("El Paso", 681124)
            };

            #region Cities-1

            #region Ex4
            Console.WriteLine("Enter value to search: ");
            string str = Console.ReadLine();
            var searchQuery = from city in citiesList
                              where city.CityName.Contains(str)
                              select city;
            #endregion

            #region Ex5
            Console.WriteLine("Enter value to search: ");
            str = Console.ReadLine();
            searchQuery = from city in citiesList
                              where city.CityName.StartsWith(str)
                              select city;
            #endregion

            #region Ex6
            searchQuery = citiesList.Where(x => x.CityName.Contains("x")).Take(1);
            #endregion

            #region Ex6
            searchQuery = citiesList.OrderBy(x => x.CityName).Take(3);
            #endregion

            foreach(var item in searchQuery)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Cities-2

            #region Ex8
            var cityQuery1 = from city in citiesList
                             where city.Population >= 1000000
                             select city;
            #endregion

            #region Ex9
            var cityQuery2 = from city in citiesList
                             where city.Population >= 1000000
                             select city.CityName;
            #endregion

            #region Ex10
            var cityQuery3 = from city in citiesList
                             select new { CityName = city.CityName, Population = city.Population, IsBigCity = true ? city.Population >= 1000000 : false };
            #endregion

            foreach (var item in cityQuery2) //cityQuery1-3
            {
                Console.WriteLine(item);
            }

            #endregion


            Console.WriteLine("\n\nPress any key to close...");
            Console.ReadKey();
        }
    }
}
