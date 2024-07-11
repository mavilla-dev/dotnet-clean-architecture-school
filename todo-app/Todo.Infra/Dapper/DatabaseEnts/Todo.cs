namespace Todo.Infra.Postgress.Dapper.Entity;

public record Todo(int Id, string Name, string Description, int Order);
