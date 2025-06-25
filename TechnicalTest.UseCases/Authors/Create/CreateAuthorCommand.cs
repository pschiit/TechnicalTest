namespace TechnicalTest.UseCases.Authors.Create;

public sealed record CreateAuthorCommand(string Name, string Surname)
    : ICommand<Guid>;