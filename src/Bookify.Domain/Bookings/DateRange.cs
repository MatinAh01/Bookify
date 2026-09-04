namespace Bookify.Domain.Bookings;

public record DateRange
{
    private DateRange()
    {
    }

    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }

    public int LengthInDays => EndDate.DayNumber - StartDate.DayNumber;

    public static DateRange Create(DateOnly startDate, DateOnly endDate)
    {
        if (startDate >= endDate)
        {
            throw new ApplicationException("end date precedes start date");
        }

        return new DateRange
        {
            StartDate = startDate,
            EndDate = endDate
        };
    }
}