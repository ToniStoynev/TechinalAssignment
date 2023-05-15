namespace InvoiceCalculator;

public record class InvoiceParameters(decimal monthlyFee,
    int smsCount,
    int mmsCount,
    int a1Minutes,
    int telenorMinutes,
    int vivacomMinutes,
    int roamingMinutes,
    decimal dataUsageInCountry,
    decimal dataUsageInEu,
    decimal dataUsageOutsideEu,
    decimal otherFees,
    decimal discount);

