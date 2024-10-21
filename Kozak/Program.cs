using Kozak.PredictModel;

class Program
{
    static void Main(string[] args)
    {
        var model = new CryptoModel();

        Console.WriteLine("Введите количество дней для расчета скользящего среднего:");
        int days = int.Parse(Console.ReadLine());

        decimal movingAverage = model.GetMovingAverage(days);
        Console.WriteLine($"Скользящее среднее за последние {days} дней: {movingAverage}");

        decimal predictedPrice = model.PredictNextPrice();
        Console.WriteLine($"Прогнозируемая цена на следующий день: {predictedPrice}");
    }
}