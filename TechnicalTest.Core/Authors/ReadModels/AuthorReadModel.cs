namespace TechnicalTest.Core.Authors.ReadModels;
public sealed record AuthorReadModel(Guid Id, string Name, string Surname) 
    : ReadModel(Id);
