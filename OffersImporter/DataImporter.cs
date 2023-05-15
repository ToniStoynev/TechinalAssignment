using Microsoft.Data.SqlClient;

namespace OffersImporter;

public class DataImporter
{
    private readonly string _connectionString;

    public DataImporter(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ImportOffers(List<Offer> offers)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Offers'";
            SqlCommand checkTableCommand = new SqlCommand(checkTableQuery, connection);
            int tableCount = (int)checkTableCommand.ExecuteScalar();

            if (tableCount == 0)
            {
                string createTableQuery = @"CREATE TABLE Offers 
                (OfferId int PRIMARY KEY, MonthlyFee decimal(12,2), NewContractsForMonth int, SameContractsForMonth int, CancelledContractsForMonth int)";
                SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
                createTableCommand.ExecuteNonQuery();
            }

            SqlCommand truncateCommand = new SqlCommand("TRUNCATE TABLE Offers", connection);
            truncateCommand.ExecuteNonQuery();

            foreach (var offer in offers)
            {
                SqlCommand command = new SqlCommand(@"INSERT INTO Offers 
                    (OfferId, MonthlyFee, NewContractsForMonth, SameContractsForMonth, CancelledContractsForMonth) 
                    VALUES (@OfferId, @MonthlyFee, @NewContractsForMonth, @SameContractsForMonth, @CancelledContractsForMonth)",
                        connection);
                command.Parameters.AddWithValue("@OfferId", offer.OfferId);
                command.Parameters.AddWithValue("@MonthlyFee", offer.MonthlyFee);
                command.Parameters.AddWithValue("@NewContractsForMonth", offer.NewContractsForMonth);
                command.Parameters.AddWithValue("@SameContractsForMonth", offer.SameContractsForMonth);
                command.Parameters.AddWithValue("@CancelledContractsForMonth", offer.CancelledContractsForMonth);
                command.ExecuteNonQuery();
            }
        }
    }
}
