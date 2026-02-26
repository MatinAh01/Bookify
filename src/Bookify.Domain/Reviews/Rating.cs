using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews;

public record Rating
{
    public int Value { get; init; }
    private Rating(int value) => Value = value;

    public static Error Invalid = new(
        "Rating.Invalid",
        "The rating is invalid");
    
    public static Result<Rating> Create(int value)
    {
        if (value < 1 || value > 5)
        {
            return Result.Failure<Rating>(Invalid);
        }

        return new Rating(value);
    }
}