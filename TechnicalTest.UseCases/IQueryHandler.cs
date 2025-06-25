using MediatR;

namespace TechnicalTest.UseCases;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
       where TQuery : IQuery<TResponse>;