using MediatR;

namespace TechnicalTest.UseCases;

/// <summary>
/// Defines a class representing a query.
/// </summary>
/// <typeparam name="TResponse">Type of Result</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>;
