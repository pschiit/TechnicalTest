using MediatR;

namespace TechnicalTest.UseCases;
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>;