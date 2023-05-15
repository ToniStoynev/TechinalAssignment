using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace OffersImporter;

public static class CsvReaders
{
    public static List<Offer> ReadOffersFromCsv(string path = "offers.csv")
    {
        

        List<Offer> offers = new List<Offer>();

        var config = new CsvConfiguration(new CultureInfo("de-DE"))
        {
            Delimiter = ";",
            PrepareHeaderForMatch
            = args => args.Header.ToLower()
        };

        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, config))
        {
            offers = csv.GetRecords<Offer>().ToList();
        }

        return offers;
    }
}
