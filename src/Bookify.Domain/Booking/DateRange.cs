using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.Domain.Booking;

public class DateRange
{
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }
    public int Lenghtdate => End.DayNumber - Start.DayNumber;

    private DateRange()
    {
        
    }

    public static DateRange Create(DateOnly strat, DateOnly end)
    {
        if (strat > end)
        {
            throw new ApplicationException("End date precedes start date");
        }

        return new()
        {
            Start = strat,
            End = end 
        };
    }
}