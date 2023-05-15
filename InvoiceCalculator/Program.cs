using InvoiceCalculator;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.Write("Месечна такса: ");
decimal monthlyFee = decimal.Parse(Console.ReadLine());

Console.Write("Брой изпратени СМС-и: ");
int smsCount = int.Parse(Console.ReadLine());

Console.Write("Брой изпратени ММС-и: ");
int mmsCount = int.Parse(Console.ReadLine());

Console.Write("Минути към А1 извън включените в пакета: ");
int a1Minutes = int.Parse(Console.ReadLine());

Console.Write("Минути към Теленор извън включените в пакета: ");
int telenorMinutes = int.Parse(Console.ReadLine());

Console.Write("Минути към Виваком извън включените в пакета: ");
int vivacomMinutes = int.Parse(Console.ReadLine());

Console.Write("Минути в роуминг: ");
int roamingMinutes = int.Parse(Console.ReadLine());

Console.Write("Използвани МБ в страната извън включените в пакета: ");
decimal dataUsageInCountry = decimal.Parse(Console.ReadLine());

Console.Write("Използвани МБ в ЕС извън включените в пакета: ");
decimal dataUsageInEu = decimal.Parse(Console.ReadLine());

Console.Write("Използвани МБ извън ЕС извън включените в пакета: ");
decimal dataUsageOutsideEu = decimal.Parse(Console.ReadLine());

Console.Write("Други такси: ");
decimal otherFees = decimal.Parse(Console.ReadLine());

Console.Write("Отстъпки: ");
decimal discount = decimal.Parse(Console.ReadLine());

decimal totalFee = InvoiceCalculator.InvoiceCalculator.CalculateTotalCost(new InvoiceParameters(monthlyFee,
    smsCount,
    mmsCount,
    a1Minutes,
    telenorMinutes,
    vivacomMinutes,
    roamingMinutes,
    dataUsageInCountry,
    dataUsageInEu,
    dataUsageOutsideEu,
    otherFees,
    discount));

Console.WriteLine($"Общо: {totalFee:F2} лв.");
Console.ReadLine();