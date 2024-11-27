using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.domain.Bookings
{
    public record DateRange
    {
        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }

        public int LengthInDays => End.Day - Start.Day;

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new ApplicationException("end date procedes srart date");
            }
            return new DateRange
            {
                Start = start,
                End = end
            };
        }
    }
}