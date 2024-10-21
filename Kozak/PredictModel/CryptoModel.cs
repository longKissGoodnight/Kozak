/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozak.PredictModel
{
    public class CryptoModel
    {
        private readonly CryptoContext _context;

        public CryptoModel(CryptoContext context)
        {
            _context = context;
        }

        // Метод для получения скользящего среднего
        public decimal GetMovingAverage(int days)
        {
            var recentPrices = _context.CryptoPrices
                                .OrderByDescending(p => p.Date)
                                .Take(days)
                                .Select(p => p.Price)
                                .ToList();

            return recentPrices.Average();
        }

        // Метод для прогнозирования на основе линейной регрессии
        public decimal PredictNextPrice()
        {
            var prices = _context.CryptoPrices
                                .OrderBy(p => p.Date)
                                .Select(p => p.Price)
                                .ToList();

            var dates = _context.CryptoPrices
                                .OrderBy(p => p.Date)
                                .Select(p => (double)p.Date.ToOADate())
                                .ToList();

            return LinearRegression(dates, prices);
        }

        // Пример простой линейной регрессии
        private decimal LinearRegression(List<double> x, List<decimal> y)
        {
            int n = x.Count;
            double sumX = x.Sum();
            double sumY = y.Sum(v => (double)v);
            double sumXy = x.Zip(y, (xi, yi) => xi * (double)yi).Sum();
            double sumX2 = x.Sum(xi => xi * xi);

            double slope = (n * sumXy - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;

            double nextX = x.Last() + 1; // Предположим, что следующий день - это просто инкремент даты

            return (decimal)(slope * nextX + intercept);
        }
    }

}*/


using System;
using System.Collections.Generic;
using System.Linq;

namespace Kozak.PredictModel
{
    public class CryptoModel
    {
        // Имитируем таблицу с данными о ценах криптовалюты
        private List<CryptoPrice> _cryptoPrices;

        public CryptoModel()
        {
            // Инициализируем список с примерными данными (можно заменить реальными)
            _cryptoPrices = new List<CryptoPrice>
            {
                new CryptoPrice { Date = DateTime.Parse("2024-10-10"), Price = 30000m },
                new CryptoPrice { Date = DateTime.Parse("2024-10-11"), Price = 30500m },
                new CryptoPrice { Date = DateTime.Parse("2024-10-12"), Price = 31000m },
                new CryptoPrice { Date = DateTime.Parse("2024-10-13"), Price = 30500m },
                new CryptoPrice { Date = DateTime.Parse("2024-10-14"), Price = 29000m },
                new CryptoPrice { Date = DateTime.Parse("2024-10-15"), Price = 15500m },
            };
        }

        // Метод для получения скользящего среднего
        public decimal GetMovingAverage(int days)
        {
            var recentPrices = _cryptoPrices
                                .OrderByDescending(p => p.Date)
                                .Take(days)
                                .Select(p => p.Price)
                                .ToList();

            return recentPrices.Average();
        }

        // Метод для прогнозирования на основе линейной регрессии
        public decimal PredictNextPrice()
        {
            var prices = _cryptoPrices
                                .OrderBy(p => p.Date)
                                .Select(p => p.Price)
                                .ToList();

            var dates = _cryptoPrices
                                .OrderBy(p => p.Date)
                                .Select(p => (double)p.Date.ToOADate())
                                .ToList();

            return LinearRegression(dates, prices);
        }

        // Пример простой линейной регрессии
        private decimal LinearRegression(List<double> x, List<decimal> y)
        {
            int n = x.Count;
            double sumX = x.Sum();
            double sumY = y.Sum(v => (double)v);
            double sumXy = x.Zip(y, (xi, yi) => xi * (double)yi).Sum();
            double sumX2 = x.Sum(xi => xi * xi);

            double slope = (n * sumXy - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double intercept = (sumY - slope * sumX) / n;

            double nextX = x.Last() + 1; // Предположим, что следующий день - это просто инкремент даты

            return (decimal)(slope * nextX + intercept);
        }

        // Класс, имитирующий запись из таблицы с данными криптовалют
        public class CryptoPrice
        {
            public DateTime Date { get; set; }
            public decimal Price { get; set; }
        }
    }


}
