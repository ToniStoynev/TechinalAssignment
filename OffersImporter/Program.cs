using OffersImporter;

//Please provide connection string to your database here
const string ConnectionString = "";

//Please provide path to the csv file here if you don't use the default path
const string PathToFile = "";

var offers = CsvReaders.ReadOffersFromCsv();

var dataImporter = new DataImporter(ConnectionString);

dataImporter.ImportOffers(offers);