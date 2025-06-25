using TechnicalTest.Core.Exceptions;

namespace TechnicalTest.Core.Guards;

public static partial class GuardClauseExtensions
{
    public static string NullOrEmpty(this IGuardClause guardClause, string input, string parameterName = "value", string? message = null)
        => string.IsNullOrEmpty(input) ? 
        throw new DomainException(message ?? $"Required input '{parameterName}' is missing.") 
        : input;
    public static Guid NullOrEmpty(this IGuardClause guardClause, Guid input, string parameterName = "value", string? message = null) 
        => input == Guid.Empty ?
            throw new DomainException(message ?? $"Required input '{parameterName}' is missing.")
            : input;
}