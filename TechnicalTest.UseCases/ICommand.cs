using MediatR;

namespace TechnicalTest.UseCases;

/// <summary>
/// Defines a class representing a command.
/// </summary>
/// <typeparam name="TResponse">Type of Result</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>;
