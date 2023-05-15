namespace InvoiceCalculator;

public static class InvoiceCalculator
{
    private static decimal CalculateSMSTax(int smsCount)
       => smsCount < 50 ? smsCount * 0.18m 
                        : smsCount >= 50 && smsCount <= 100 
                        ? smsCount * 0.16m 
                        : smsCount * 0.11m;

    private static decimal CalculateMMSTax(int mmsCount)
        => mmsCount < 50 ? mmsCount * 0.25m 
                         : mmsCount >= 50 && mmsCount <= 100 
                         ? mmsCount * 0.23m 
                         : mmsCount * 0.18m;

    private static decimal CalculateMinuteTax(string operatorName, int minutes)
        => operatorName.ToLower() switch
        {
            "a1" => minutes * 0.03m,
            _ => minutes * 0.09m,
        };

    private static decimal CalculateRoamingTax(int minutes)
       => minutes * 0.15m;

    private static decimal CalculateDataTax(string region, decimal dataUsage)
    {
        switch (region.ToLower())
        {
            case "eu":
                return dataUsage * 0.05m;
            case "non-eu":
                return dataUsage * 0.20m;
            default:
                return dataUsage * 0.02m;
        }
    }

    public static decimal CalculateTotalCost(InvoiceParameters invoiceParameters)
    {
        decimal totalCost = invoiceParameters.monthlyFee;

        totalCost += CalculateSMSTax(invoiceParameters.smsCount);

        totalCost += CalculateMMSTax(invoiceParameters.mmsCount);

        totalCost += CalculateMinuteTax("a1", invoiceParameters.a1Minutes);
        totalCost += CalculateMinuteTax("telenor", invoiceParameters.telenorMinutes);
        totalCost += CalculateMinuteTax("vivacom", invoiceParameters.vivacomMinutes);
        totalCost += CalculateRoamingTax(invoiceParameters.roamingMinutes);

        totalCost += CalculateDataTax("in-country", invoiceParameters.dataUsageInCountry);
        totalCost += CalculateDataTax("eu", invoiceParameters.dataUsageInEu);
        totalCost += CalculateDataTax("non-eu", invoiceParameters.dataUsageOutsideEu);

        totalCost += invoiceParameters.otherFees;
        totalCost -= invoiceParameters.discount;

        return totalCost;
    }
}
