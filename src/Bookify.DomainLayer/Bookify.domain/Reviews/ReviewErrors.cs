using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Abstractions;

namespace Bookify.domain.Reviews
{
    public static class ReviewErrors
    {
        public static readonly Error NotEligible = new(
            "Review.NotEligible",
            "The review is not eligible because the booking is not yet completed");
    }
}